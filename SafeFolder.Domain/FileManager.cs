using System.Collections.Generic;
using SafeFolder.Core.Contracts;
using SafeFolder.Core.Entities;
using File = SafeFolder.Core.Entities.File;

namespace SafeFolder.Domain
{
    public class FileManager : IFileManager
    {
        #region Member Variables
        private readonly IFileRepo _fileRepo;
        #endregion

        #region Properties
        public string FileLocation { get; set; }
        #endregion

        #region Constructors

        public FileManager(IFileRepo fileRepo)
        {
            _fileRepo = fileRepo;
        }

        #endregion

        public void SaveFileSettings(File file, List<AddressBook> addresses) 
        {
            //TODO: Call the encryption service here
            var newFileName = file.Name + ".safe";
            System.IO.File.Move(file.Name, newFileName);

            //TODO: Depending on what happens with the encryption service or if the application is online we'll set flags on the file before we save it
            var result = _fileRepo.SaveSettings(file, addresses);
        }

        public void DeleteFileSettings(FileRecipient filesettings)
        {
            _fileRepo.DeleteSettings(filesettings);
        }

        public List<FileRecipient> GetAllSavedFiles()
        {
            return _fileRepo.GetAllSavedFiles();
        }
    }
}
