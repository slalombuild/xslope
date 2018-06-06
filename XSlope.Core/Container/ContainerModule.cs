using XSlope.Core.Providers.Interfaces;
using XSlope.Core.Providers;
using XSlope.Core.Managers.Interfaces;
using XSlope.Core.Managers;

namespace XSlope.Core.Container
{
    public class ContainerModule : BaseContainerModule
    {
        readonly string _appName;

        public ContainerModule(string appName)
        {
            _appName = appName;
        }

        public override void Load()
        {
            // Managers
            Bind<IAuthenticationManager>().To<AuthenticationManager>().InSingletonScope();
            Bind<ICacheManager>().To<AkavacheCacheManager>().InSingletonScope();

            // Providers
            Bind<IAppNameProvider>().ToConstant(new AppNameProvider(_appName));
            Bind<ICacheProvider>().To<AkavacheCacheProvider>();
        }
    }
}
