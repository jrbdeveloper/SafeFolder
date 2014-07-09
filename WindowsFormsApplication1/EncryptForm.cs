using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafeFolder
{
    public partial class EncryptForm : Form
    {
        public EncryptForm()
        {
            InitializeComponent();
        }

        public CheckedListBox EmailList
        {
            get { return lstRecipients; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstRecipients.Items.Add(txtEmailAddress.Text, true);
            txtEmailAddress.Text = "";
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            ///TODO: Call the encryption service here to collect all the info about the file and encrypt it
            this.Close();
        }

        private void EncryptForm_Load(object sender, EventArgs e)
        {
            ///TODO: Get the list of existing email addresses from the database and load the list box
        }
    }
}
