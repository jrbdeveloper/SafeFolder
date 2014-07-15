﻿using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using SafeFolder.Core.Contracts;
using SafeFolder.Core.Entities;

namespace SafeFolder
{
    public partial class SafeFolderForm : Form
    {
        #region Member Variables

        private Configuration _defaultConfiguration;
        private readonly IConfigurationManager _configurationManager;
        #endregion

        #region Properties
        private DataGridView Grid
        {
            get { return configurationList; }
        }

        public Configuration DefaultConfiguration {
            get { return _defaultConfiguration ?? (_defaultConfiguration = _configurationManager.GetDefaultConfiguration()); }
            set { _defaultConfiguration = value; }
        }

        #endregion

        #region Constructor
        public SafeFolderForm(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;

            InitializeComponent();
            InitializeSafeFolder();
            ShowInTaskbar = false;
        }
        #endregion

        #region Event Handlers
        private void SafeFolder_Load(object sender, EventArgs e)
        {
            InitializeSafeFolder();
        }

        private void saveConfigurationBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(configName.Text) || string.IsNullOrEmpty(localPath.Text) ||
                string.IsNullOrEmpty(emailAddress.Text) || string.IsNullOrEmpty(servicePath.Text))
            {
                MessageBox.Show("You must complete all fields.");
            }
            else
            {
                SaveConfiguration();
                ClearFields();

                InitializeSafeFolder();
            }
        }
        
        private void fileSysWatcher_Created(object sender, FileSystemEventArgs e)
        {
           // MessageBox.Show("Created");
            FileOrFolderChanged(e);        
        }

        private void fileSysWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            //MessageBox.Show("Changed");
            FileOrFolderChanged(e);        
        }

        private void FileOrFolderChanged(FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                if (Directory.Exists(e.FullPath))
                {
                    // a new directory was created
                    //MWS: TODO  code for Folders being added
                }
                else
                {
                    var fileForm = new FileForm {FileName = e.FullPath};
                    fileForm.ShowDialog();
                }
            }
        }

        private void ShowSafeFolder(object sender, EventArgs e)
        {
            //InitializeLocalPath();
            System.Diagnostics.Process.Start("explorer.exe", DefaultConfiguration.LocalFilePath);
        }

        private void ShowConfigurationForm(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            
            Show();
        }

        private void SafeFolder_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void configurationList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //var grid = (DataGridView)sender;
            //configName.Text = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            //localPath.Text = grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            //emailAddress.Text = grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            //servicePath.Text = grid.Rows[e.RowIndex].Cells[3].Value.ToString();
            //isDefaultCheck.Checked = bool.Parse(grid.Rows[e.RowIndex].Cells[4].Value.ToString());

            //_activeRowIndex = e.RowIndex;
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SafeFolderForm_FormClosing(object sender, CancelEventArgs e)
        {
            if (!Visible && WindowState == FormWindowState.Normal)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                Hide();
            }
        }
        #endregion

        #region Private Methods
        private void ClearFields()
        {
            configName.Text = string.Empty;
            localPath.Text = string.Empty;
            emailAddress.Text = string.Empty;
            servicePath.Text = string.Empty;
            isDefaultCheck.Checked = false;
        }

        private void SaveConfiguration()
        {
            try
            {
                var newConfig = new Configuration
                {
                    Name = configName.Text,
                    LocalFilePath = localPath.Text,
                    ServicePath = servicePath.Text,
                    IsDefault = isDefaultCheck.Checked,
                    OwnerProfile = new OwnerProfile
                    {
                        FirstName = firstName.Text,
                        LastName = lastName.Text,
                        EmailAddress = emailAddress.Text,
                        Password = password.Text
                    }
                };

                _configurationManager.SaveConfiguration(newConfig);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Method to create a file system watcher so that we can monitor when files are added
        /// </summary>
        private void InitializeFileSystemWatcher()
        {
            var fileSysWatcher = new FileSystemWatcher
            {
                Path = DefaultConfiguration.LocalFilePath,
                Filter = "*.*",
                NotifyFilter =
                    NotifyFilters.CreationTime |
                    NotifyFilters.LastAccess |
                    NotifyFilters.LastWrite |
                    NotifyFilters.FileName |
                    NotifyFilters.DirectoryName,
            };

            //TODO: Adjust these filters if we're not getting the write notification/triggers
            fileSysWatcher.Changed += fileSysWatcher_Changed;
            fileSysWatcher.Created += fileSysWatcher_Created;
            fileSysWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Method to initialize the context menu on the tray icon
        /// </summary>
        private void InitializeTrayMenu()
        {
            notifyIcon1.ContextMenu = new ContextMenu();
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Show Safe Folder", ShowSafeFolder));
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Show Configuration", ShowConfigurationForm));
            notifyIcon1.ContextMenu.MenuItems.Add("-");
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Quit Safe Folder", Exit));
        }

        /// <summary>
        /// Method to create the folder path if it does not exist
        /// </summary>
        /// <param name="path">string</param>
        private void InitializeLocalPath()
        {
            if (!Directory.Exists(DefaultConfiguration.LocalFilePath))
            {
                Directory.CreateDirectory(DefaultConfiguration.LocalFilePath);
            }
        }

        private void InitializeSafeFolder()
        {
            DefaultConfiguration = _configurationManager.GetDefaultConfiguration();
            Grid.DataSource = _configurationManager.GetAllConfigurations();

            InitializeLocalPath();
            InitializeTrayMenu();
            InitializeFileSystemWatcher();
        }
        #endregion 
    }
}
