using SafeFolder.Core.Entities;
using SafeFolder.Data.Repositories;

namespace SafeFolder.Domain
{
    public class FileManager
    {
        #region Member Variables
        private readonly FileRepo _fileRepo = new FileRepo();
        #endregion

        #region Properties
        public string FileLocation { get; set; }
        #endregion

        public void SaveFile(File file) 
        {
            //SaveFileSettings(file);

            //TODO: Call the encryption service here
            var newFileName = file.Name + ".safe";
            System.IO.File.Move(file.Name, newFileName);
        }

        private void SaveFileSettings(File file)
        {
            var result = _fileRepo.SaveSettings(file);
        }

        private void DeleteFileSettings(File file)
        {
            _fileRepo.DeleteSettings(file);
        }
    }
}
