using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class EncryptionPreferencesManager
    {

        public static EncryptForm EncryptPreferencesForm = null;



        public List<string> ShowEncryptForm()
        {
            List<string> emailList = new List<string>();
            try
            {
                if (EncryptPreferencesForm == null)
                {
                    EncryptPreferencesForm = new EncryptForm();
                    //encryptForm.FormClosed += delegate { encryptForm = null; };
                }
                EncryptPreferencesForm.ShowDialog();
                if (EncryptPreferencesForm.DialogResult == DialogResult.OK)
                {
                    emailList = (from string e in EncryptPreferencesForm.EmailList.CheckedItems
                                 select e).ToList<string>();

                }
            }
            catch
            {
                System.Diagnostics.Debugger.Break();
            }
            finally
            {
                if (EncryptPreferencesForm != null)
                {
                    EncryptPreferencesForm.Dispose();
                    EncryptPreferencesForm = null;
                }
            }
            return emailList;
        }
    }
}
