using System;
using System.Windows.Forms;
using SafeFolder.Infrastructure;

namespace SafeFolder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CompositionRoot.InitializeKernel();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(CompositionRoot.Resolve<SafeFolderForm>());
        }
    }
}
