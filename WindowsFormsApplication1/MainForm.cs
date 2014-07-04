﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeFolder
{
    public partial class SafeFolder : Form
    {
        #region Member Variables
        private string _safeFolderPath = @"c:\SafeFolder";
        private FileSystemWatcher _fileSysWatcher;
        private int _activeRowIndex = -1;
        #endregion

        #region Properties
        private DataGridView Grid
        {
            get { return (DataGridView)configurationList; }
        }

        private int GridRowCount
        {
            get { return configurationList.Rows.Count; }
        }
        #endregion

        #region Constructor
        public SafeFolder()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void SafeFolder_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            CreateIfNotExists(_safeFolderPath);

            InitializeTrayMenu();
            InitializeFileSystemWatcher();
        }

        private void addServiceLocation_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            if (GridRowCount > 2 && _activeRowIndex != -1)
            {
                ResetDefaultConfiguration();
                row = SetRowValues();
                ClearFields();
            }
            else
            {
                if (string.IsNullOrEmpty(configName.Text) || string.IsNullOrEmpty(localPath.Text) || string.IsNullOrEmpty(emailAddress.Text) || string.IsNullOrEmpty(servicePath.Text))
                {
                    MessageBox.Show("You must complete all fields.");
                }
                else
                {
                    configurationList.Rows.Add(SetRowValues());
                    _activeRowIndex = -1;
                    ClearFields();                    
                }
            }
        }
        
        private void fileSysWatcher_Created(object sender, FileSystemEventArgs e)
        {
            FileExtensionFilter();
        }

        private void fileSysWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            FileExtensionFilter();
        }

        private void ShowSafeFolder(object sender, EventArgs e)
        {
            CreateIfNotExists(_safeFolderPath);

            System.Diagnostics.Process.Start("explorer.exe", _safeFolderPath);
        }

        private void ShowConfigurationForm(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void SafeFolder_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void configurationList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            configName.Text = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
            localPath.Text = grid.Rows[e.RowIndex].Cells[1].Value.ToString();
            emailAddress.Text = grid.Rows[e.RowIndex].Cells[2].Value.ToString();
            servicePath.Text = grid.Rows[e.RowIndex].Cells[3].Value.ToString();
            isDefaultCheck.Checked = bool.Parse(grid.Rows[e.RowIndex].Cells[4].Value.ToString());

            _activeRowIndex = e.RowIndex;
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

        private DataGridViewRow SetRowValues()
        {
            var row = (DataGridViewRow)configurationList.Rows[0].Clone();

            row.Cells[0].Value = configName.Text;
            row.Cells[1].Value = localPath.Text;
            row.Cells[2].Value = emailAddress.Text;
            row.Cells[3].Value = servicePath.Text;
            row.Cells[4].Value = isDefaultCheck.Checked;

            return row;
        }

        /// <summary>
        /// Method to check the grid for rows that are marked as default and update them because we want a new default
        /// </summary>
        private void ResetDefaultConfiguration()
        {
            foreach (var item in configurationList.Rows)
            {
                var row = (DataGridViewRow)item;

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
            _fileSysWatcher = new FileSystemWatcher();
            _fileSysWatcher.Path = _safeFolderPath;

            //TODO: Adjust these filters if we're not getting the write notification/triggers
            _fileSysWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            _fileSysWatcher.Filter = "*.*";
            _fileSysWatcher.Changed += fileSysWatcher_Changed;
            _fileSysWatcher.Created += fileSysWatcher_Created;
            //fileSysWatcher.Deleted += fileSysWatcher_Deleted;
            //fileSysWatcher.Renamed += fileSysWatcher_Renamed;
            _fileSysWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Method to initialize the context menu on the tray icon
        /// </summary>
        private void InitializeTrayMenu()
        {
            this.notifyIcon1.ContextMenu = new ContextMenu();
            this.notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Show Safe Folder", new EventHandler(ShowSafeFolder)));
            this.notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Show Configuration", new EventHandler(ShowConfigurationForm)));
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

        /// <summary>
        /// Method to rename each file in the directory that doesn't have the .safe extension
        /// </summary>
        private void FileExtensionFilter()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_safeFolderPath);
            foreach (var item in dirInfo.GetFiles("*.*"))
            {
                if (item.Extension != ".safe")
                {
                    var newFileName = item.FullName;
                    newFileName += ".safe";

                    File.Move(item.FullName, newFileName);
                }
            }
        }
        #endregion
                
        //void fileSysWatcher_Renamed(object sender, RenamedEventArgs e)
        //{
        //    MessageBox.Show("File Renamed");
        //}

        //void fileSysWatcher_Deleted(object sender, FileSystemEventArgs e)
        //{
        //    MessageBox.Show("File Delete");
        //}
    }
}
