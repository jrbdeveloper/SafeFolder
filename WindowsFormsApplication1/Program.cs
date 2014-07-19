using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using SafeFolder.Core.Contracts;
using SafeFolder.Infrastructure;

namespace SafeFolder
{
    internal static class Program
    {
        private const string _mutexId = @"Global\UniqueSafeFolderProgramId";
        private static Mutex _mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool instanceAlreadyRunning = SomeInstanceIsAlreadyRunning() | SomeInstanceIsAlreadyRunning1();

            if (instanceAlreadyRunning || !VerifyAdminPrivileges())
            {
                return;
            }

            //create the mutex so we can tell if there is another instance running
            _mutex = new Mutex(true, _mutexId);

            TaskTrayService.StartSysTrayAutomatically();

            CompositionRoot.InitializeKernel();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(CompositionRoot.Resolve<SafeFolderForm>());

            _mutex.Close();
        }

        public static bool SomeInstanceIsAlreadyRunning()
        {
            bool alreadyRunning = false;
            try
            {
                Mutex.OpenExisting(_mutexId);
                alreadyRunning = true;
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                alreadyRunning = false;
            }
            catch
            {
                alreadyRunning = true;
            }
            return alreadyRunning;
        }

        public static bool SomeInstanceIsAlreadyRunning1()
        {
            Process[] runningProcesses = Process.GetProcesses();

            var query = from rp in runningProcesses
                where rp.ProcessName.ToLower() == "SafeFolder"
                select rp;

            if (query.Count() > 1)
                return true;

            return false;
        }

        public static bool VerifyAdminPrivileges()
        {
            WindowsPrincipal myPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (myPrincipal.IsInRole(WindowsBuiltInRole.Administrator) == false)
            {
                //show messagebox - displaying a messange to the user that rights are missing
                MessageBox.Show("You need to run the application using the \"run as administrator\" option",
                    "administrator right required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }

    }
}
