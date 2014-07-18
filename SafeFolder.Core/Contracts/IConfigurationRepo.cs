using System.Collections.Generic;
using SafeFolder.Core.Entities;

namespace SafeFolder.Core.Contracts
{
    public interface IConfigurationRepo
    {
        int Save(Configuration config);
        void Delete(Configuration config);
        List<Configuration> GetAll();
        Configuration GetById(int id);
        Configuration GetByName(string name);
        Configuration GetDefault();
        OwnerProfile GetDefaultOwnerProfile();
    }
}
