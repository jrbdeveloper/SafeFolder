using System.Collections.Generic;
using System.Linq;

namespace SafeFolder.Data.Repositories
{
    public class ConfigurationRepo
    {
        public int Save(Configuration config)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                data.Configurations.Add(config);

                if (data.ChangeTracker.HasChanges())
                {
                    result = data.SaveChanges();
                }
            }

            return result;
        }

        public List<Configuration> GetAll()
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

        public Configuration GetDefault()
        {
            using (var data = new SafeFolderEntities())
            {
                var result = from config in data.Configurations.Where(x => x.IsDefault) select config;

                return result.FirstOrDefault();
            }
        }
    }
}
