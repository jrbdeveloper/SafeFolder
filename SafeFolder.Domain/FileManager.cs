using System.Collections.Generic;
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

        public void SaveFileSettings(List<FileRecipient> filesettings) 
        {
            //TODO: Call the encryption service here
            var newFileName = filesettings[0].File.Name + ".safe";
            System.IO.File.Move(filesettings[0].File.Name, newFileName);

            //TODO: Depending on what happens with the encryption service or if the application is online we'll set flags on the file before we save it
            var result = _fileRepo.SaveSettings(filesettings);
        }

        private void DeleteFileSettings(File file)
        {
            _fileRepo.DeleteSettings(file);
        }
    }
}
