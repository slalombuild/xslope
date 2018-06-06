using System.Collections.Generic;
using Foundation;
using UIKit;
using XSlope.Core.Container;
using XSlope.Core.Helpers;
using STARTER_APP.iOS.ViewControllers;
using STARTER_APP.Core.Resources;

namespace STARTER_APP.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Bootstrap();

            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new UINavigationController(new HelloWorldViewController())
            };

            Window.MakeKeyAndVisible();

            return true;
        }

        void Bootstrap()
        {
            var appModules = new List<BaseContainerModule>
            {
                new XSlope.iOS.Container.ContainerModule(),
                new Core.Container.ContainerModule(),
                new Container.ContainerModule()
            };

            Bootstrapper.Initialize(appModules, LocalizedStrings.AppName);
        }
    }
}
