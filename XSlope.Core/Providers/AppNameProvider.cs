using System;
using XSlope.Core.Providers.Interfaces;

namespace XSlope.Core.Providers
{
    public class AppNameProvider : IAppNameProvider
    {
        public AppNameProvider(string appName)
        {
            AppName = appName;
        }

        public string AppName { get; private set; }
    }
}
