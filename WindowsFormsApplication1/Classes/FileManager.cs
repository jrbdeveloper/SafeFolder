using System.IO;
using SafeFolder.Data.Repositories;

namespace SafeFolder.Classes
{
    public class FileManager
    {
        #region Member Variables
        private readonly FileRepo _fileRepo = new FileRepo();
        #endregion

        #region Properties
        public string FileLocation { get; set; }
        #endregion

        public void SaveFile(Data.File file) 
        {
            SaveFileSettings(file);

            //TODO: Call the encryption service here
            var newFileName = file.Name + ".safe";
            File.Move(file.Name, newFileName);
        }

        private void SaveFileSettings(Data.File file)
        {
            var result = _fileRepo.SaveSettings(file);
        }

        private void DeleteFileSettings(Data.File file)
        {
            _fileRepo.DeleteSettings(file);
        }
    }
}
