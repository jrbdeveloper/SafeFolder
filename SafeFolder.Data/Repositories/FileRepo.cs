using System.Collections.Generic;
using System.Linq;
using SafeFolder.Core.Contracts;

namespace SafeFolder.Data.Repositories
{
    public class FileRepo : IFileRepo
    {
        public int SaveSettings(Core.Entities.File file, List<Core.Entities.AddressBook> addresses)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                // Save file so it can be used in the next block of code
                var savedFile = SaveFile(file);

                // Construct a FileRecipient object to persist
                foreach (var address in addresses)
                {
                    var savedAddress = data.AddressBooks.FirstOrDefault(x => x.EmailAddress == address.EmailAddress);

                    data.FileRecipients.Add(new FileRecipient
                    {
                        AddressBookId = savedAddress.Id,
                        FileId = savedFile.Id
                    });
                }

                if (data.ChangeTracker.HasChanges())
                {
                    result = data.SaveChanges();
                }
            }

            return result;
        }

        public void DeleteSettings(Core.Entities.FileRecipient file)
        {
        }

        #region Private Methods
        private File SaveFile(Core.Entities.File file)
        {
            using (var data = new SafeFolderEntities())
            {
                var f = new File
                {
                    Name = file.Name,
                    Path = file.Path,
                    CanCopy = file.CanCopy,
                    CanDelete = file.CanDelete,
                    CanForward = file.CanForward,
                    CanModify = file.CanModify
                };

                data.Files.Add(f);
                data.SaveChanges();

                return f;
            }
        }
        #endregion
    }
}
