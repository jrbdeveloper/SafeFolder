using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SafeFolder.Classes;
using SafeFolder.Data;
using File = System.IO.File;

namespace SafeFolder
{
    public partial class SafeFolderForm : Form
    {
        #region Member Variables
        private string _safeFolderPath = @"c:\SafeFolder";
        private FileSystemWatcher _fileSysWatcher;
        private static EncryptionPreferencesManager _encryptionPrefManager = new EncryptionPreferencesManager();
        private EncryptionService _encryptionService = new EncryptionService();
        private ConfigurationManager _configManager = new ConfigurationManager();
        private int _activeRowIndex = -1;
        private List<string> _emailList;
        #endregion

        #region Properties
        private DataGridView Grid
        {
            get { return configurationList; }
        }

        private int GridRowCount
        {
            get { return Grid.RowCount; }
        }

        public List<string> EmailAdressses 
        { 
            get { return _emailList ?? new List<string>(); } 
            set { _emailList = value; } 
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
            CreateIfNotExists(_safeFolderPath);

            InitializeTrayMenu();
            InitializeFileSystemWatcher();
            EmailAdressses = new List<string>();

            Grid.DataSource = _configManager.GetAllConfigurations();
        }

        private void addServiceLocation_Click(object sender, EventArgs e)
        {
            if (GridRowCount > 2 && _activeRowIndex != -1)
            {
                ResetDefaultConfiguration();
                CreateRecord();
                ClearFields();
            }
            else
            {
                if (string.IsNullOrEmpty(configName.Text) || string.IsNullOrEmpty(localPath.Text) ||
                    string.IsNullOrEmpty(emailAddress.Text) || string.IsNullOrEmpty(servicePath.Text))
                {
                    MessageBox.Show("You must complete all fields.");
                }
                else
                {
                    CreateRecord();
                    _activeRowIndex = -1;
                    ClearFields();
                }
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
                    _encryptionService.FileLocation = e.FullPath;
                    _encryptionService.EncryptFile();

                    //A file was creeated
                    FileExtensionFilter();
                }
            }
        }

        private void ShowSafeFolder(object sender, EventArgs e)
        {
            CreateIfNotExists(_safeFolderPath);

            System.Diagnostics.Process.Start("explorer.exe", _safeFolderPath);
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

        private void ShowEncryptForm(object sender, EventArgs e)
        {
            ShowEncryptForm();
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

        //private void HydrateConfigurationManager()
        //{
        //    _configManager.Owner.FirstName = firstName.Text;
        //    _configManager.Owner.LastName = lastName.Text;
        //    _configManager.Owner.Password = password.Text;
        //    _configManager.Owner.EmailAddress = emailAddress.Text;
        //    _configManager.Owner.Configurations.Add(new Configuration
        //    {
        //        Name = configName.Text,
        //        LocalFilePath = localPath.Text,
        //        ServicePath = servicePath.Text,
        //        IsDefault = isDefaultCheck.Checked
        //    });
        //}

        private void CreateRecord()
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

            try
            {
                _configManager.Save(newConfig);
            }
            catch (Exception ex)
            {
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
            notifyIcon1.ContextMenu = new ContextMenu();
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Show Safe Folder", ShowSafeFolder));
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Show Configuration", ShowConfigurationForm));
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Encrypt Files", ShowEncryptForm));
            notifyIcon1.ContextMenu.MenuItems.Add("-");
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Quit Safe Folder", Exit));
        }

        private static List<string> ShowEncryptForm()
        {
            List<string> emailList = new List<string>();

             _encryptionPrefManager.ShowEncryptForm();
             emailList = _encryptionPrefManager.emailList;

            return emailList;
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
            List<string> emailList = ShowEncryptForm();
            DirectoryInfo dirInfo = new DirectoryInfo(_safeFolderPath);
            foreach (var item in dirInfo.GetFiles("*.*"))
            {
                if (item.Extension != ".safe")
                {
                    var newFileName = item.FullName;
                    newFileName += ".safe";

                    EncryptFiles(item, newFileName);
                }
            }
        }

        private void EncryptFiles(FileInfo item, string newFileName)
        {
            //This fakes the encryption
            //EmailAdressses  This property contains the addresses to encrypt for
            File.Move(item.FullName, newFileName);
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
