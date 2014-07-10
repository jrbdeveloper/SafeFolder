
using System.IO;

namespace SafeFolder.Classes
{
    public class EncryptionService
    {
        #region Member Variables
        private readonly ConfigurationManager _configurationManager = new ConfigurationManager();
        #endregion

        public string FileLocation { get; set; }

        public void EncryptFile(Data.File file) 
        {
            FileExtensionFilter(file);
        }

        public void DecryptFile() 
        {
            //File.Decrypt(FileLocation);
        }

        /// <summary>
        /// Method to rename each file in the directory that doesn't have the .safe extension
        /// </summary>
        private void FileExtensionFilter(Data.File file)
        {
            var newFileName = file.Name + ".safe";
            File.Move(file.Name, newFileName);

            //var dirInfo = new DirectoryInfo(_configurationManager.DefaultConfiguration.LocalFilePath);
            //foreach (var item in dirInfo.GetFiles("*.*"))
            //{
            //    if (item.Extension != ".safe")
            //    {
            //        var newFileName = item.FullName;
            //        newFileName += ".safe";

            //        File.Move(item.FullName, newFileName);
            //    }
            //}
        }
    }
}
