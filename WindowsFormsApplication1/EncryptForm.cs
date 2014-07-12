using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SafeFolder.Classes;
using SafeFolder.Data;

namespace SafeFolder
{
    public partial class EncryptForm : Form
    {
        #region Member Variables
        private readonly EncryptionManager _encryptionManager = new EncryptionManager();
        private readonly AddressBookManager _addressBookManager = new AddressBookManager();
        private List<FileRecipient> _recipients; 
        #endregion

        #region Properties

        public string FileName { get; set; }

        public List<FileRecipient> Recipients
        {
            get { return _recipients ?? (_recipients = new List<FileRecipient>()); }
            set { _recipients = value; }
        }

        public CheckedListBox EmailList
        {
            get { return lstRecipients; }
        }
        #endregion

        #region Constructor
        public EncryptForm()
        {
            InitializeComponent();
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var address = new AddressBook
            {
                EmailAddress = txtEmailAddress.Text
            };

            _addressBookManager.SaveAddress(address);

            lstRecipients.Items.Clear();

            LoadAddressList();

            AddRecipientToList(address);

            txtEmailAddress.Text = "";
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            ///TODO: Call the encryption service here to collect all the info about the file and encrypt it

            var file = new Data.File
            {
                Name = FileName,
                Path = "",
                FileRecipients = Recipients
            };

            _encryptionManager.EncryptFile(file);
            Hide();
        }

        private void EncryptForm_Load(object sender, EventArgs e)
        {
            FullFileName.Text = FileName;

            LoadAddressList();
        }

        private void EncryptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        #region Private Methods
        private void LoadAddressList()
        {
            foreach (var item in _addressBookManager.GetAllAddresses())
            {
                lstRecipients.Items.Add(item.EmailAddress, true);
            }
        }

        private void AddRecipientToList(AddressBook addressBookItem)
        {
            var recipient = new FileRecipient
            {
                AddressBook = addressBookItem,
                File = new Data.File
                {
                    Name = FileName,
                    Path = ""
                }
            };

            Recipients.Add(recipient);
        }
        #endregion
    }
}
