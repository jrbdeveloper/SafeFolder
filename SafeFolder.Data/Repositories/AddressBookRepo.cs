using System.Collections.Generic;
using System.Linq;
using SafeFolder.Core.Contracts;

namespace SafeFolder.Data.Repositories
{
    public class AddressBookRepo : IAddressBookRepo
    {
        public int Save(Core.Entities.AddressBook addressBook)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                data.AddressBooks.Add(new AddressBook
                {
                    EmailAddress = addressBook.EmailAddress
                });

                if (data.ChangeTracker.HasChanges())
                {
                    result = data.SaveChanges();
                }
            }

            return result;
        }

        public void Delete(Core.Entities.AddressBook addressBook)
        {
        }

        public List<Core.Entities.AddressBook> GetAll()
        {
            using (var data = new SafeFolderEntities())
            {
                return data.AddressBooks.Select(item => new Core.Entities.AddressBook
                { EmailAddress = item.EmailAddress }).ToList();
            }
        }
    }
}
