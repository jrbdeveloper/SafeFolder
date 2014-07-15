using System.Collections.Generic;
using SafeFolder.Core.Contracts;

namespace SafeFolder.Data.Repositories
{
    public class FileRepo : IFileRepo
    {
        public int SaveSettings(List<Core.Entities.FileRecipient> filesettings)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                foreach (var fileRecipient in filesettings)
                {
                    data.FileRecipients.Add(new FileRecipient
                    {
                        File = new File
                        {
                            Name = fileRecipient.File.Name,
                            Path = fileRecipient.File.Path,
                            CanCopy = fileRecipient.File.CanCopy,
                            CanDelete = fileRecipient.File.CanDelete,
                            CanForward = fileRecipient.File.CanForward,
                            CanModify = fileRecipient.File.CanModify
                        },

                        AddressBook = new AddressBook
                        {
                            EmailAddress = fileRecipient.AddressBook.EmailAddress
                        }
                    });

                    if (data.ChangeTracker.HasChanges())
                    {
                        result = data.SaveChanges();
                    }
                }
            }

            return result;
        }

        public void DeleteSettings(Core.Entities.FileRecipient file)
        {
        }
    }
}
