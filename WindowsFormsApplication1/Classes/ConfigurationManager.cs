using SafeFolder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFolder.Classes
{
    public class ConfigurationManager
    {
        #region Member Variables
        private Owner _owner;
        #endregion

        #region Properties

        public Owner Owner 
        { 
            get { return _owner ?? (_owner = new Owner()); }
            set { _owner = value; } 
        }
        
        #endregion

        #region Constructor
        public ConfigurationManager()
        { }
        #endregion

        #region Public Methods
        public bool Save()
        {
            return true;
        }

        public Configuration GetById(int Id)
        {
            return new Configuration();
        }

        public Configuration GetDefault()
        {
            return new Configuration();
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
