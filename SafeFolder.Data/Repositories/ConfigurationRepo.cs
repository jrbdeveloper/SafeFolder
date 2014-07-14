using System.Collections.Generic;
using System.Linq;

namespace SafeFolder.Data.Repositories
{
    public class ConfigurationRepo
    {
        public int Save(Core.Entities.Configuration config)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                data.Configurations.Add(new Configuration
                {
                    Name = config.Name,
                    LocalFilePath = config.LocalFilePath,
                    ServicePath = config.ServicePath,
                    IsDefault = config.IsDefault,
                    OwnerProfile = new OwnerProfile
                    {
                        FirstName = config.OwnerProfile.FirstName,
                        LastName = config.OwnerProfile.LastName,
                        EmailAddress = config.OwnerProfile.EmailAddress,
                        Password = config.OwnerProfile.Password
                    }
                });

                if (data.ChangeTracker.HasChanges())
                {
                    result = data.SaveChanges();
                }
            }

            return result;
        }

        public void Delete(Core.Entities.Configuration config)
        {
            
        }

        public List<Core.Entities.Configuration> GetAll()
        {
            var configList = new List<Core.Entities.Configuration>();

            using (var data = new SafeFolderEntities())
            {
                foreach (var config in data.Configurations)
                {
                    configList.Add(new Core.Entities.Configuration
                    {
                        Name = config.Name,
                        LocalFilePath = config.LocalFilePath,
                        ServicePath = config.ServicePath,
                        IsDefault = config.IsDefault,
                        OwnerProfile = new Core.Entities.OwnerProfile
                        {
                            FirstName = config.OwnerProfile.FirstName,
                            LastName = config.OwnerProfile.LastName,
                            EmailAddress = config.OwnerProfile.EmailAddress,
                            Password = config.OwnerProfile.Password
                        }
                    });
                }

                return configList;
            }
        }

        public Core.Entities.Configuration GetById(int id)
        {
            using (var data = new SafeFolderEntities())
            {
                var result = from config in data.Configurations.Where(x => x.Id == id) select config;
                var configuration = result.FirstOrDefault();

                if (configuration != null)
                {
                    return new Core.Entities.Configuration
                    {
                        Name = configuration.Name,
                        LocalFilePath = configuration.LocalFilePath,
                        ServicePath = configuration.ServicePath,
                        IsDefault = configuration.IsDefault,
                        OwnerProfile = new Core.Entities.OwnerProfile
                        {
                            FirstName = configuration.OwnerProfile.FirstName,
                            LastName = configuration.OwnerProfile.LastName,
                            EmailAddress = configuration.OwnerProfile.EmailAddress,
                            Password = configuration.OwnerProfile.Password
                        }
                    };
                }
                
                return new Core.Entities.Configuration();
            }
        }

        public Core.Entities.Configuration GetDefault()
        {
            using (var data = new SafeFolderEntities())
            {
                var result = from config in data.Configurations.Where(x => x.IsDefault) select config;
                var configuration = result.FirstOrDefault();

                if (configuration != null)
                {
                    return new Core.Entities.Configuration
                    {
                        Name = configuration.Name,
                        LocalFilePath = configuration.LocalFilePath,
                        ServicePath = configuration.ServicePath,
                        IsDefault = configuration.IsDefault,
                        OwnerProfile = new Core.Entities.OwnerProfile
                        {
                            FirstName = configuration.OwnerProfile.FirstName,
                            LastName = configuration.OwnerProfile.LastName,
                            EmailAddress = configuration.OwnerProfile.EmailAddress,
                            Password = configuration.OwnerProfile.Password
                        }
                    };
                }

                return new Core.Entities.Configuration
                {
                    LocalFilePath = @"c:\SafeFolder"
                };
            }
        }
    }
}
