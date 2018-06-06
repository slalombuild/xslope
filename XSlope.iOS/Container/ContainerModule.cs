using System;
using XSlope.Core.Container;
using XSlope.iOS.Providers.Interfaces;
using XSlope.iOS.Providers;
using XSlope.Core.Providers.Interfaces;

namespace XSlope.iOS.Container
{
    public class ContainerModule : BaseContainerModule
    {
        public override void Load()
        {
            // Providers
            Bind<ILogProvider>().To<SerilogLogProvider>();
            Bind<IProgressHUDProvider>().To<BTProgressHUDProvider>();
        }
    }
}
