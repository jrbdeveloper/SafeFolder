using System.Collections.Generic;
using SafeFolder.Core.Entities;

namespace SafeFolder.Core.Contracts
{
    public interface IFileManager
    {
        void SaveFileSettings(File file, List<AddressBook> addresses);
        void DeleteFileSettings(FileRecipient filesettings);
        List<FileRecipient> GetAllSavedFiles();
    }
}
