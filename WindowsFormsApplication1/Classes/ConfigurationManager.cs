using System.Collections.Generic;
using System.Linq;
using SafeFolder.Data;

namespace SafeFolder.Classes
{
    public class ConfigurationManager
    {
        #region Member Variables
        private OwnerProfile _owner;
        #endregion

        #region Properties

        public OwnerProfile Owner 
        { 
            get { return _owner ?? (_owner = new OwnerProfile()); }
            set { _owner = value; } 
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
