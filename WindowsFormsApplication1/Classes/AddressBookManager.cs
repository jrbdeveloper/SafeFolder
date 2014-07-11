
using System.Collections.Generic;
using SafeFolder.Data;
using SafeFolder.Data.Repositories;

namespace SafeFolder.Classes
{
    public class AddressBookManager
    {
        #region Member Variables
        private readonly AddressBookRepo _addressBookRepo = new AddressBookRepo();
        #endregion

        public void SaveAddress(AddressBook addressBook)
        {
            var result = _addressBookRepo.Save(addressBook);
        }

        public List<AddressBook> GetAllAddresses()
        {
            return _addressBookRepo.GetAll();
        }
    }
}
