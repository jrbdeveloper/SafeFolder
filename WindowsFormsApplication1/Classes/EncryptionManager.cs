
using System.IO;

namespace SafeFolder.Classes
{
    public class EncryptionManager
    {
        #region Member Variables
        private readonly ConfigurationManager _configurationManager = new ConfigurationManager();
        #endregion

        public string FileLocation { get; set; }

        public void EncryptFile(Data.File file) 
        {
            var newFileName = file.Name + ".safe";
            File.Move(file.Name, newFileName);
        }

        public void DecryptFile() 
        {
            //File.Decrypt(FileLocation);
        }

        //private void FileExtensionFilter(Data.File file)
        //{
        //    var dirInfo = new DirectoryInfo(_configurationManager.DefaultConfiguration.LocalFilePath);
        //    foreach (var item in dirInfo.GetFiles("*.*"))
        //    {
        //        if (item.Extension != ".safe")
        //        {
        //            var newFileName = item.FullName;
        //            newFileName += ".safe";

        //            File.Move(item.FullName, newFileName);
        //        }
        //    }
        //}
    }
}
