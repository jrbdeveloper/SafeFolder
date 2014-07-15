using System.Collections.Generic;
using SafeFolder.Core.Entities;
using SafeFolder.Data.Repositories;

namespace SafeFolder.Domain
{
    public class ConfigurationManager
    {
        #region Member Variables
        private Configuration _defaultConfiguration;
        private readonly ConfigurationRepo _configurationRepo = new ConfigurationRepo();
        #endregion

        #region Properties

        public Configuration DefaultConfiguration
        {
            get { return _defaultConfiguration ?? (_defaultConfiguration = GetDefaultConfiguration()); }
        }
        #endregion

        #region Constructor
        #endregion

        #region Public Methods
        public void SaveConfiguration(Configuration config)
        {
            var result = _configurationRepo.Save(config);

            _defaultConfiguration = GetDefaultConfiguration();
        }

        public void DeleteConfiguration(Configuration config)
        {
            _configurationRepo.Delete(config);
        }

        public List<Configuration> GetAllConfigurations()
        {
            return _configurationRepo.GetAll();
        }

        public Configuration GetById(int id)
        {
            return _configurationRepo.GetById(id);
        }

        public Configuration GetDefaultConfiguration()
        {
            return _configurationRepo.GetDefault();
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
