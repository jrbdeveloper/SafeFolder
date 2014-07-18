using System.Collections.Generic;
using SafeFolder.Core.Entities;

namespace SafeFolder.Core.Contracts
{
    public interface IConfigurationManager
    {
        Configuration DefaultConfiguration { get; }

        void SaveConfiguration(Configuration config);
        void DeleteConfiguration(Configuration config);
        List<Configuration> GetAllConfigurations();
        Configuration GetById(int id);
        Configuration GetByName(string name);
        Configuration GetDefaultConfiguration();
        OwnerProfile GetDefaultOwnerProfile();

        void InitializeLocalPath();
    }
}
