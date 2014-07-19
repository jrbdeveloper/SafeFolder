using System.Collections.Generic;
using SafeFolder.Core.Entities;

namespace SafeFolder.Core.Contracts
{
    public interface IFileRepo
    {
        int SaveSettings(File file, List<AddressBook> addresses);
        void DeleteSettings(FileRecipient file);
        List<Core.Entities.FileRecipient> GetAllSavedFiles();
    }
}
