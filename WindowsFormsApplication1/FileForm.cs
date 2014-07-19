using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SafeFolder.Core.Contracts;
using SafeFolder.Core.Entities;

namespace SafeFolder
{
    public partial class FileForm : Form
    {
        #region Member Variables
        private readonly IFileManager _fileManager;
        private readonly IAddressBookManager _addressBookManager;
        private readonly IConfigurationManager _configurationManager; 
        #endregion

        #region Properties
        public string FileName { get; set; }
        #endregion

        #region Constructors
        public FileForm(IFileManager fileManager, IAddressBookManager addressBookManager, IConfigurationManager configurationManager)
        {
            _fileManager = fileManager;
            _addressBookManager = addressBookManager;
            _configurationManager = configurationManager;

            InitializeComponent();
        }

        #endregion

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            AddAddress();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            AddAddress();

            var addresses = new List<AddressBook>();
            var file = new File
            {
                Name = FileName,
                Path = _configurationManager.DefaultConfiguration.LocalFilePath,
                CanCopy = canCopyCheck.Checked,
                CanForward = canForwardCheck.Checked,
                CanDelete = canDeleteCheck.Checked,
                CanModify = canModifyCheck.Checked,
            };

            foreach (var fileRecipient in GetRecipients())
            {
                addresses.Add(fileRecipient.AddressBook);
            }

            _fileManager.SaveFileSettings(file, addresses);
            Close();
        }

        private void FileForm_Load(object sender, EventArgs e)
        {
            FullFileName.Text = FileName;

            LoadAddressList();
        }

        private void FileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void checkAllAddresses_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;

            for (var x = 0; x < lstRecipients.Items.Count; x++)
            {
                lstRecipients.SetItemChecked(x, checkBox.Checked);
            }
        }

        #region Private Methods
        private void LoadAddressList()
        {
            lstRecipients.Items.Clear();

            foreach (var item in _addressBookManager.GetAllAddresses())
            {
                lstRecipients.Items.Add(item.EmailAddress, true);
            }
        }

        private List<FileRecipient> GetRecipients()
        {
            var list = new List<FileRecipient>();
            for (int i = 0; i < lstRecipients.Items.Count; i++)
            {
                if (lstRecipients.GetItemChecked(i))
                {
                    var str = (string)lstRecipients.Items[i];
                    list.Add(new FileRecipient
                    {
                        AddressBook = new AddressBook
                        {
                            EmailAddress = str
                        }
                    });
                }
            }

            return list;
        }

        private void AddAddress()
        {
            if (!string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                var address = new AddressBook
                {
                    EmailAddress = txtEmailAddress.Text
                };

                _addressBookManager.SaveAddress(address);
                LoadAddressList();

                txtEmailAddress.Text = "";
            }
        }

        #endregion
    }
}
