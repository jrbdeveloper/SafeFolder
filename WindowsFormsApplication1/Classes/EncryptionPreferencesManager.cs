using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SafeFolder.Classes
{
    public class EncryptionPreferencesManager
    {
        private static System.Timers.Timer _elapseTimer;
        public List<string> emailList = new List<string>();
        public static EncryptForm EncryptPreferencesForm = null;
        
        public List<string> ShowEncryptForm()
        {           
            try
            {
                if (EncryptPreferencesForm == null)
                {
                    EncryptPreferencesForm = new EncryptForm();

                    EncryptPreferencesForm.ShowDialog();
                    if (EncryptPreferencesForm.DialogResult == DialogResult.OK)
                    {
                        emailList = (from string e in EncryptPreferencesForm.EmailList.CheckedItems
                                     select e).ToList<string>();

                    }
                    SetupTimer();
                }
                else
                {
                    ResetTimer();
                }

            }
            catch
            {
                System.Diagnostics.Debugger.Break();
            }
            finally
            {
                //if (EncryptPreferencesForm != null)
                //{
                //    EncryptPreferencesForm.Dispose();
                //    EncryptPreferencesForm = null;
                //}
            }
            return emailList;
        }

        private void SetupTimer()
        {
            _elapseTimer = new System.Timers.Timer(10000);

            // Hook up the event handler for the Elapsed event.
            _elapseTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnPreferencesTimeOut);

            // Only raise the event the first time Interval elapses.
            _elapseTimer.AutoReset = false;
            _elapseTimer.Enabled = true;
        }

        private void ResetTimer()
        {
            _elapseTimer.Enabled = false;
            _elapseTimer.Elapsed -= new System.Timers.ElapsedEventHandler(OnPreferencesTimeOut);
            _elapseTimer.Dispose();
            SetupTimer();
        }

        private void OnPreferencesTimeOut(object sender, System.Timers.ElapsedEventArgs e)
        {
            emailList = null;
            if (EncryptPreferencesForm != null)
            {
                EncryptPreferencesForm.Dispose();
                EncryptPreferencesForm = null;
            }
        }
    }
}
