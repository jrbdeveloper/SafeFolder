﻿using SafeFolder.Core.Entities;
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
            //TODO: Call the encryption service here
            var newFileName = file.Name + ".safe";
            System.IO.File.Move(file.Name, newFileName);

            //TODO: Depending on what happens with the encryption service or if the application is online we'll set flags on the file before we save it
            //SaveFileSettings(file);
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