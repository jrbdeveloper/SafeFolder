using System.Collections.Generic;

namespace SafeFolder.Core.Contracts
{
    public interface IAddressBookManager
    {
        void SaveAddress(Core.Entities.AddressBook addressBook);
        void DeleteAddress(Core.Entities.AddressBook addressBook);
        List<Entities.AddressBook> GetAllAddresses();
    }
}
