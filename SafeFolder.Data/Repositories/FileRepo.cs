using System.Collections.Generic;
using System.Linq;
using SafeFolder.Core.Contracts;

namespace SafeFolder.Data.Repositories
{
    public class FileRepo : IFileRepo
    {
        #region Public Methods
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

        public List<Core.Entities.FileRecipient> GetAllSavedFiles()
        {
            using (var data = new SafeFolderEntities())
            {
                var files = from fileRecipient in data.FileRecipients
                    join file in data.Files on fileRecipient.FileId equals file.Id
                    join address in data.AddressBooks on fileRecipient.AddressBookId equals address.Id
                    select new Core.Entities.FileRecipient
                    {
                        AddressBook = new Core.Entities.AddressBook
                        {
                            EmailAddress = address.EmailAddress
                        },
                        File = new Core.Entities.File
                        {
                            Name = file.Name,
                            Path = file.Path,
                            CanCopy = file.CanCopy,
                            CanDelete = file.CanDelete,
                            CanModify = file.CanModify,
                            CanForward = file.CanForward,
                        }
                    };

                return files.ToList();
            }
        }
        #endregion

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
