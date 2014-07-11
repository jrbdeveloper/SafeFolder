using System.Collections.Generic;
using System.Linq;

namespace SafeFolder.Data.Repositories
{
    public class AddressBookRepo
    {
        public int Save(AddressBook addressBook)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                data.AddressBooks.Add(addressBook);

                if (data.ChangeTracker.HasChanges())
                {
                    result = data.SaveChanges();
                }
            }

            return result;
        }

        public List<AddressBook> GetAll()
        {
            using (var data = new SafeFolderEntities())
            {
                return data.AddressBooks.ToList();
            }
        }
    }
}
