using System.Collections.Generic;
using SafeFolder.Data.Repositories;

namespace SafeFolder.Domain
{
    public class AddressBookManager
    {
        #region Member Variables
        private readonly AddressBookRepo _addressBookRepo = new AddressBookRepo();
        #endregion

        public void SaveAddress(Core.Entities.AddressBook addressBook)
        {
            var result = _addressBookRepo.Save(addressBook);
        }

        public List<Core.Entities.AddressBook> GetAllAddresses()
        {
            return _addressBookRepo.GetAll();
        }
    }
}
