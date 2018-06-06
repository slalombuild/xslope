using System;
using System.Collections.Generic;
using Android.App;
using Android.Runtime;
using XSlope.Core.Container;
using XSlope.Core.Helpers;
using STARTER_APP.Core.Resources;

namespace STARTER_APP.Droid
{
    [Application]
    public class App : Application
    {
        public static App Instance { get; private set; }

        public App(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip) { }

        public override void OnCreate()
        {
            base.OnCreate();
            Instance = this;
            Bootstrap();
        }

        void Bootstrap()
        {
            var appModules = new List<BaseContainerModule>
            {
                new XSlope.Droid.Container.ContainerModule(),
                new Core.Container.ContainerModule(),
                new Container.ContainerModule()
            };

            Bootstrapper.Initialize(appModules, LocalizedStrings.AppName);
        }
    }
}
