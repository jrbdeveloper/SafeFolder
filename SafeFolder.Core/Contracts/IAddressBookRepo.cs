using System.Collections.Generic;

namespace SafeFolder.Core.Contracts
{
    public interface IAddressBookRepo
    {
        int Save(Entities.AddressBook addressBook);
        void Delete(Entities.AddressBook addressBook);
        List<Entities.AddressBook> GetAll();
    }
}
