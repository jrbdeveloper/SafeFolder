using System.Collections.Generic;
using System.Linq;

namespace SafeFolder.Data.Repositories
{
    public class AddressBookRepo
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

        public List<Core.Entities.AddressBook> GetAll()
        {
            using (var data = new SafeFolderEntities())
            {
                var list = new List<Core.Entities.AddressBook>();

                foreach (var item in data.AddressBooks)
                {
                    list.Add(new Core.Entities.AddressBook
                    {
                        EmailAddress = item.EmailAddress
                    });
                }

                return list;
            }
        }
    }
}
