using System.Collections.Generic;
using SafeFolder.Core.Entities;

namespace SafeFolder.Core.Contracts
{
    public interface IFileManager
    {
        void SaveFileSettings(List<FileRecipient> filesettings);

        void DeleteFileSettings(FileRecipient filesettings);
    }
}
