using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SafeFolder.Classes;
using SafeFolder.Data;

namespace SafeFolder
{
    public partial class EncryptForm : Form
    {
        #region Member Variables
        private readonly EncryptionService _encryptionService = new EncryptionService();
        private List<FileRecipient> _recipients; 
        #endregion

        #region Properties

        public string FileName { get; set; }

        public List<FileRecipient> Recipients
        {
            get { return _recipients ?? (_recipients = new List<FileRecipient>()); }
            set { _recipients = value; }
        }
        #endregion

        #region Constructor
        public EncryptForm()
        {
            InitializeComponent();
        }
        #endregion

        public CheckedListBox EmailList
        {
            get { return lstRecipients; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstRecipients.Items.Add(txtEmailAddress.Text, true);

            var recipient = new FileRecipient
            {
                AddressBook = new AddressBook
                {
                    EmailAddress = txtEmailAddress.Text
                },
                File = new Data.File
                {
                    Name = FileName,
                    Path = ""
                }
            };

            Recipients.Add(recipient);

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

            _encryptionService.EncryptFile(file);
            Hide();
        }

        private void EncryptForm_Load(object sender, EventArgs e)
        {
            FullFileName.Text = FileName;

            ///TODO: Get the list of existing email addresses from the database and load the list box
        }

        private void EncryptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
