using System.Collections.Generic;

namespace SafeFolder.Core.Contracts
{
    public interface IFileRepo
    {
        int SaveSettings(List<Entities.FileRecipient> filesettings);
        void DeleteSettings(Entities.FileRecipient file);
    }
}
