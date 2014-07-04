using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EncryptForm : Form
    {
        public EncryptForm()
        {
            InitializeComponent();
        }

        public CheckedListBox EmailList
        {
            get
            {
                return lstRecipients;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstRecipients.Items.Add(txtEmailAddress.Text, true);
            txtEmailAddress.Text = "";
        }
    }
}
