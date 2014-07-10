using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using SafeFolder.Data;

namespace SafeFolder.Classes
{
    public class ConfigurationManager
    {
        #region Member Variables
        private OwnerProfile _owner;
        private Configuration _defaultConfiguration;
        #endregion

        #region Properties

        public OwnerProfile Owner 
        { 
            get { return _owner ?? (_owner = new OwnerProfile()); }
            set { _owner = value; } 
        }

        public Configuration DefaultConfiguration
        {
            get { return _defaultConfiguration ?? (_defaultConfiguration = GetDefaultConfiguratoin()); }
        }
        #endregion

        #region Constructor
        public ConfigurationManager()
        { }
        #endregion

        #region Public Methods
        public void Save(Configuration config)
        {
            using (var data = new SafeFolderEntities())
            {
                data.Configurations.Add(config);
                data.SaveChanges();
            }
        }

        public List<Configuration> GetAllConfigurations()
        {
            using (var data = new SafeFolderEntities())
            {
                return data.Configurations.ToList();
            }
        }

        public Configuration GetById(int id)
        {
            using (var data = new SafeFolderEntities())
            {
                var result = from config in data.Configurations.Where(x => x.Id == id) select config;

                return result.FirstOrDefault();
            }
        }

        public Configuration GetDefaultConfiguratoin()
        {
            using (var data = new SafeFolderEntities())
            {
                var result = from config in data.Configurations.Where(x => x.IsDefault) select config;

                return result.FirstOrDefault();
            }
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
