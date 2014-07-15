namespace SafeFolder.Core.Entities
{
    public class FileRecipient
    {
        #region Member Variables
        private AddressBook _addressBook;
        private File _file;
        #endregion

        #region Properties
        public AddressBook AddressBook {
            get { return _addressBook ?? (_addressBook = new AddressBook()); }
            set { _addressBook = value; }
        }

        public File File {
            get { return _file ?? (_file = new File()); }
            set { _file = value; }
        }
        #endregion
    }
}
