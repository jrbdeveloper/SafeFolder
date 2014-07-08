using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFolder.Classes
{
    public class ConfigurationManager
    {
        #region Properties
        
        public string UserFirstName { get; set; }
        
        public string UserLastName { get; set; }
        
        public string UserEmailAddress { get; set; }
        
        public string UserPassword { get; set; }

        public List<Config> Configurations { get; set; }
        
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

        public Config GetById(int Id)
        {
            return new Config();
        }
        #endregion

        #region Private Methods
        #endregion

        public class Config
        {
            public int ConfigurationId { get; set; }

            public string ConfigurationName { get; set; }

            public string LocalFilePath { get; set; }

            public string ServiceFilePath { get; set; }

            public bool IsDefault { get; set; }
        }
    }
}
