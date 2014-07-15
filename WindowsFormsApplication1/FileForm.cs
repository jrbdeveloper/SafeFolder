﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SafeFolder.Core.Entities;
using SafeFolder.Domain;

namespace SafeFolder
{
    public partial class FileForm : Form
    {
        #region Member Variables
        private readonly FileManager _fileManager = new FileManager();
        private readonly AddressBookManager _addressBookManager = new AddressBookManager();
        private readonly ConfigurationManager _configurationManager = new ConfigurationManager();

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
        public FileForm()
        {
            InitializeComponent();
        }
        #endregion

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            var address = new AddressBook
            {
                EmailAddress = txtEmailAddress.Text
            };

            _addressBookManager.SaveAddress(address);
            LoadAddressList();

            txtEmailAddress.Text = "";
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            var list = new List<FileRecipient>();
            foreach (var fileRecipient in GetRecipients())
            {
                list.Add(new FileRecipient
                {
                    File = new File
                    {
                        Name = FileName,
                        Path = _configurationManager.DefaultConfiguration.LocalFilePath,
                        CanCopy = canCopyCheck.Checked,
                        CanForward = canForwardCheck.Checked,
                        CanDelete = canDeleteCheck.Checked,
                        CanModify = canModifyCheck.Checked,
                    },
                    AddressBook = new AddressBook
                    {
                        EmailAddress = fileRecipient.AddressBook.EmailAddress
                    }
                });
            }

            _fileManager.SaveFileSettings(list);
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

        #endregion
    }
}
