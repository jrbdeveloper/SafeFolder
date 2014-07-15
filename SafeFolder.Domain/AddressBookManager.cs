using System.Collections.Generic;
using SafeFolder.Core.Contracts;

namespace SafeFolder.Domain
{
    public class AddressBookManager : IAddressBookManager
    {
        #region Member Variables
        private readonly IAddressBookRepo _addressBookRepo;
        #endregion

        #region Constructors

        public AddressBookManager(IAddressBookRepo addressBookRepo)
        {
            _addressBookRepo = addressBookRepo;
        }

        #endregion

        public void SaveAddress(Core.Entities.AddressBook addressBook)
        {
            var result = _addressBookRepo.Save(addressBook);
        }

        public void DeleteAddress(Core.Entities.AddressBook addressBook)
        {
            _addressBookRepo.Delete(addressBook);
        }

        public List<Core.Entities.AddressBook> GetAllAddresses()
        {
            return _addressBookRepo.GetAll();
        }
    }
}
