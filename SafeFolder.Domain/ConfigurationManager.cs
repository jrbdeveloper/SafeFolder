using System.Collections.Generic;
using SafeFolder.Core.Contracts;
using SafeFolder.Core.Entities;

namespace SafeFolder.Domain
{
    public class ConfigurationManager : IConfigurationManager
    {
        #region Member Variables
        private Configuration _defaultConfiguration;
        private readonly IConfigurationRepo _configurationRepo;
        #endregion

        #region Properties

        public Configuration DefaultConfiguration
        {
            get { return _defaultConfiguration ?? (_defaultConfiguration = GetDefaultConfiguration()); }
        }
        #endregion

        #region Constructor

        public ConfigurationManager(IConfigurationRepo configurationRepo)
        {
            _configurationRepo = configurationRepo;
        }

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
