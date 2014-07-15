using System.Collections.Generic;

namespace SafeFolder.Core.Contracts
{
    public interface IAddressBookManager
    {
        void SaveAddress(Entities.AddressBook addressBook);
        void DeleteAddress(Entities.AddressBook addressBook);
        List<Entities.AddressBook> GetAllAddresses();
    }
}
