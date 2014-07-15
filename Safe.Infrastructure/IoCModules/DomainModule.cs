using Ninject.Modules;
using SafeFolder.Core.Contracts;
using SafeFolder.Domain;

namespace SafeFolder.Infrastructure
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAddressBookManager>().To<AddressBookManager>();
            Bind<IConfigurationManager>().To<ConfigurationManager>();
            Bind<IFileManager>().To<FileManager>();
        }
    }
}
