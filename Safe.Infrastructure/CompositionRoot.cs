using Ninject;
using Ninject.Modules;
using SafeFolder.Infrastructure;

namespace SafeFolder.Core
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static INinjectModule[] GetRegisteredModules()
        {
            var modules = new INinjectModule[]
            {
                new DataModule(),
                new DomainModule()
            };

            return modules;
        }

        public static void Wire()
        {
            _ninjectKernel = new StandardKernel(GetRegisteredModules());
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
