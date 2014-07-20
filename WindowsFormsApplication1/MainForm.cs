using System;
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

        private readonly IFileManager _fileManager;
        private readonly IAddressBookManager _addressBookManager;
        private readonly IConfigurationManager _configurationManager; 
        #endregion

        #region Properties
        private DataGridView Grid
        {
            get { return configurationList; }
        }
        #endregion

        #region Constructor
        public SafeFolderForm(IFileManager fileManager, IAddressBookManager addressBookManager, IConfigurationManager configurationManager)
        {
            _fileManager = fileManager;
            _addressBookManager = addressBookManager;
            _configurationManager = configurationManager;

            InitializeComponent();
            InitializeSafeFolder();
            InitializeFileSystemWatcher();
            ShowInTaskbar = false;
        }
        #endregion

        #region Event Handlers
        private void SafeFolder_Load(object sender, EventArgs e)
        {
            InitializeSafeFolder();
            LimitOneConfiguration();
        }

        private void SafeFolder_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
            }
        }

        private void saveConfigurationBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(configName.Text) || string.IsNullOrEmpty(localPath.Text) ||
                string.IsNullOrEmpty(emailAddress.Text))
            {
                MessageBox.Show("You must complete all fields.");
            }
            else
            {
                SaveConfiguration();
                InitializeSafeFolder();
                LimitOneConfiguration();
            }
        }

        private void deleteConfigurationBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this configuration?", "Confirm Delete",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var config = _configurationManager.GetByName(configName.Text);

                if (config != null)
                {
                    _configurationManager.DeleteConfiguration(config);
                    ClearFields();
                    Grid.DataSource = _configurationManager.GetAllConfigurations();
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
                    using (var fileForm = new FileForm(_fileManager, _addressBookManager, _configurationManager))
                    {
                        fileForm.FileName = e.FullPath;
                        fileForm.ShowDialog(this);
                    }
                }
            }
        }

        private void ShowSafeFolder(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", _configurationManager.DefaultConfiguration.LocalFilePath);
        }

        private void ShowConfigurationForm(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Show();
        }

        private void ShowFileReportForm(object sender, EventArgs e)
        {
            var fileReport = new FileReport(_configurationManager, _fileManager);
            fileReport.Show();
        }

        private void configurationList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ResetGridSelection((DataGridView)sender);
            ClearFields();
        }

        private void configurationList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ResetGridSelection((DataGridView)sender);
            ClearFields();
        }

        private void configurationList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ResetGridSelection((DataGridView)sender);
        }

        private void configurationList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetGridRowValues((DataGridView)sender, e.RowIndex);
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SafeFolderForm_FormClosing(object sender, CancelEventArgs e)
        {
            //if (!Visible && WindowState == FormWindowState.Normal)
            //{
            //    Application.Exit();
            //}
            //else
            //{
            //    e.Cancel = true;
            //    Hide();
            //}
            
            e.Cancel = true;
            Hide();
        }
        #endregion

        #region Private Methods
        private void ClearFields()
        {
            configName.Text = string.Empty;
            localPath.Text = string.Empty;
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
                Path = _configurationManager.DefaultConfiguration.LocalFilePath,
                Filter = "*.*",
                NotifyFilter =
                    NotifyFilters.CreationTime |
                    NotifyFilters.LastAccess |
                    NotifyFilters.LastWrite |
                    NotifyFilters.FileName |
                    NotifyFilters.Size |
                    NotifyFilters.DirectoryName,
            };

            //TODO: Adjust these filters if we're not getting the write notification/triggers
            fileSysWatcher.Changed += fileSysWatcher_Changed;
            fileSysWatcher.Created += fileSysWatcher_Created;
            fileSysWatcher.SynchronizingObject = this;
            fileSysWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Method to initialize the context menu on the tray icon
        /// </summary>
        private void InitializeTrayMenu()
        {
            notifyIcon1.ContextMenu = new ContextMenu();
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Open Safe Folder", ShowSafeFolder));
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Configurations", ShowConfigurationForm));
            //notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("File Settings Report", ShowFileReportForm));
            notifyIcon1.ContextMenu.MenuItems.Add("-");
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Quit Safe Folder", Exit));
        }

        private void InitializeSafeFolder()
        {
            Grid.DataSource = _configurationManager.GetAllConfigurations();

            _configurationManager.InitializeLocalPath();
            SetDefaultOwner();
            InitializeTrayMenu();
        }

        private void GetGridRowValues(DataGridView grid, int rowIndex)
        {
            var model = _configurationManager.GetByName(grid.Rows[rowIndex].Cells[0].Value.ToString());

            firstName.Text = model.OwnerProfile.FirstName;
            lastName.Text = model.OwnerProfile.LastName;
            emailAddress.Text = model.OwnerProfile.EmailAddress;
            password.Text = model.OwnerProfile.Password;

            configName.Text = model.Name;
            localPath.Text = model.LocalFilePath;
            servicePath.Text = model.ServicePath;
            isDefaultCheck.Checked = model.IsDefault;
        }

        private void ResetGridSelection(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                row.Selected = false;
            }

            foreach (DataGridViewCell cell in grid.SelectedCells)
            {
                cell.Selected = false;
            }

            foreach (DataGridViewColumn col in grid.SelectedColumns)
            {
                col.Selected = false;
            }
        }

        private void SetDefaultOwner()
        {
            var owner = _configurationManager.GetDefaultOwnerProfile();

            if (owner != null)
            {
                firstName.Text = owner.FirstName;
                lastName.Text = owner.LastName;
                emailAddress.Text = owner.EmailAddress;
                password.Text = owner.Password;
            }
        }

        private void LimitOneConfiguration()
        {
            if (Grid.RowCount > 0)
            {
                saveConfigurationBtn.Enabled = false;
            }
        }

        #endregion 
    }
}
