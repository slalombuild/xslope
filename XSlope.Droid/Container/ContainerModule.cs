using System;
using XSlope.Core.Container;
using XSlope.Core.Providers.Interfaces;
using XSlope.Droid.Providers;
using XSlope.Droid.Providers.Interfaces;

namespace XSlope.Droid.Container
{
    public class ContainerModule : BaseContainerModule
    {
        public override void Load()
        {
            // Providers
            Bind<ILogProvider>().To<SerilogLogProvider>();
            Bind<IProgressHUDProvider>().To<AndProgressHUDProvider>();
        }
    }
}
