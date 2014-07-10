using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SafeFolder.Classes;
using SafeFolder.Data;

namespace SafeFolder
{
    public partial class SafeFolderForm : Form
    {
        #region Member Variables
        private FileSystemWatcher _fileSysWatcher;
        private readonly ConfigurationManager _configurationManager = new ConfigurationManager();
        #endregion

        #region Properties
        private DataGridView Grid
        {
            get { return configurationList; }
        }
        #endregion

        #region Constructor
        public SafeFolderForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void SafeFolder_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            CreateIfNotExists(_configurationManager.DefaultConfiguration.LocalFilePath);

            InitializeTrayMenu();
            InitializeFileSystemWatcher();

            Grid.DataSource = _configurationManager.GetAllConfigurations();
        }

        private void addServiceLocation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(configName.Text) || string.IsNullOrEmpty(localPath.Text) ||
                string.IsNullOrEmpty(emailAddress.Text) || string.IsNullOrEmpty(servicePath.Text))
            {
                MessageBox.Show("You must complete all fields.");
            }
            else
            {
                CreateRecord();
                ClearFields();
            }
        }
        
        private void fileSysWatcher_Created(object sender, FileSystemEventArgs e)
        {
            FileOrFolderChanged(e);        
        }

        private void fileSysWatcher_Changed(object sender, FileSystemEventArgs e)
        {
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
                    var encryptionForm = new EncryptForm {FileName = e.FullPath};
                    encryptionForm.ShowDialog();
                }
            }
        }

        private void ShowSafeFolder(object sender, EventArgs e)
        {
            CreateIfNotExists(_configurationManager.DefaultConfiguration.LocalFilePath);
            System.Diagnostics.Process.Start("explorer.exe", _configurationManager.DefaultConfiguration.LocalFilePath);
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

        private void CreateRecord()
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

                _configurationManager.Save(newConfig);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to check the grid for rows that are marked as default and update them because we want a new default
        /// </summary>
        private void ResetDefaultConfiguration()
        {
            foreach (DataGridViewRow row in configurationList.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    var isDefaultChecked = bool.Parse(row.Cells[4].Value.ToString());

                    if(isDefaultChecked)
                    {
                        row.Cells[4].Value = false;
                    }
                }
            }
        }

        /// <summary>
        /// Method to create a file system watcher so that we can monitor when files are added
        /// </summary>
        private void InitializeFileSystemWatcher()
        {
            _fileSysWatcher = new FileSystemWatcher
            {
                Path = _configurationManager.DefaultConfiguration.LocalFilePath,
                Filter = "*.*",
                NotifyFilter =
                    NotifyFilters.CreationTime |
                    NotifyFilters.LastAccess |
                    NotifyFilters.LastWrite |
                    NotifyFilters.FileName |
                    NotifyFilters.DirectoryName,
            };

            //TODO: Adjust these filters if we're not getting the write notification/triggers
            _fileSysWatcher.Changed += fileSysWatcher_Changed;
            _fileSysWatcher.Created += fileSysWatcher_Created;
            _fileSysWatcher.EnableRaisingEvents = true;
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
        private void CreateIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        #endregion
    }
}
