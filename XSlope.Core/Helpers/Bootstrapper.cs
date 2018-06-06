using System;
using System.Collections.Generic;
using XSlope.Core.Container;

namespace XSlope.Core.Helpers
{
    public static class Bootstrapper
    {
        public static void Initialize(List<BaseContainerModule> appContainerModules, string appName)
        {
            var containerModules = new List<BaseContainerModule> { new ContainerModule(appName) };
            containerModules.AddRange(appContainerModules);
            DependencyContainer.Build(containerModules);
        }
    }
}
