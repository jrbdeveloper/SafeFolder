﻿using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using SafeFolder.Core.Contracts;

namespace SafeFolder.Data.Repositories
{
    public class ConfigurationRepo : IConfigurationRepo
    {
        public int Save(Core.Entities.Configuration config)
        {
            int result = 0;

            using (var data = new SafeFolderEntities())
            {
                var model = data.Configurations.FirstOrDefault(x=>x.Name == config.Name);

                if (model != null)
                {
                    model = HydrateModel(model, config, false);
                    data.Configurations.Attach(model);
                    data.Entry(model).State = EntityState.Modified;
                    //data.Configurations.Add(model);
                }
                else
                {
                    var newModel = HydrateModel(model, config, true);
                    data.Configurations.Add(newModel);
                }

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
                    configList.Add(HydrateEntity(config));
                }

                return configList;
            }
        }

        public Core.Entities.Configuration GetById(int id)
        {
            using (var data = new SafeFolderEntities())
            {
                var model = data.Configurations.FirstOrDefault(x => x.Id == id);

                if (model != null)
                {
                    return HydrateEntity(model);
                }
                
                return new Core.Entities.Configuration();
            }
        }

        public Core.Entities.Configuration GetByName(string name)
        {
            using (var data = new SafeFolderEntities())
            {
                var model = data.Configurations.FirstOrDefault(x => x.Name == name);

                if (model != null)
                {
                    return HydrateEntity(model);
                }

                return new Core.Entities.Configuration();
            }
        }

        public Core.Entities.Configuration GetDefault()
        {
            using (var data = new SafeFolderEntities())
            {
                if (data.Database.Connection.State == ConnectionState.Closed)
                {
                    data.Database.Connection.Open();
                }

                Configuration configuration = null;
                var result = from config in data.Configurations.Where(x => x.IsDefault) select config;

                if (result.Any())
                {
                    configuration = result.FirstOrDefault();
                    
                    if (configuration != null)
                    {
                        return HydrateEntity(configuration);
                    }
                }

                return new Core.Entities.Configuration
                {
                    LocalFilePath = @"c:\SafeFolder"
                };
            }
        }

        private Core.Entities.Configuration HydrateEntity(Configuration configuration)
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

        private Configuration HydrateModel(Configuration existingModel, Core.Entities.Configuration config, bool includeOwner)
        {
            Configuration model = null;

            if (existingModel != null)
            {
                model = existingModel;
                model.Name = config.Name;
                model.IsDefault = config.IsDefault;
                model.LocalFilePath = config.LocalFilePath;
                model.ServicePath = config.ServicePath;
                model.OwnerProfile.FirstName = config.OwnerProfile.FirstName;
                model.OwnerProfile.LastName = config.OwnerProfile.LastName;
                model.OwnerProfile.EmailAddress = config.OwnerProfile.EmailAddress;
                model.OwnerProfile.Password = config.OwnerProfile.Password;
            }
            else
            {
                model = new Configuration
                {
                    Name = config.Name,
                    LocalFilePath = config.LocalFilePath,
                    ServicePath = config.ServicePath,
                    IsDefault = config.IsDefault,
                    OwnerProfile = (includeOwner)
                        ? new OwnerProfile
                        {
                            FirstName = config.OwnerProfile.FirstName,
                            LastName = config.OwnerProfile.LastName,
                            EmailAddress = config.OwnerProfile.EmailAddress,
                            Password = config.OwnerProfile.Password
                        }
                        : null
                };
            }

            return model;
        }
    }
}
