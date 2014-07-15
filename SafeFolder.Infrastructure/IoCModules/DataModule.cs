using Ninject.Modules;
using SafeFolder.Core.Contracts;
using SafeFolder.Data.Repositories;

namespace SafeFolder.Infrastructure.IoCModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAddressBookRepo>().To<AddressBookRepo>();
            Bind<IConfigurationRepo>().To<ConfigurationRepo>();
            Bind<IFileRepo>().To<FileRepo>();
        }
    }
}
