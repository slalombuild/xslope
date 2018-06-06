using Foundation;
using UIKit;

namespace XSlope.iOS.Extensions
{
    public static class UIApplicationExtensions
    {
        public static void NavigateToUrl(this UIApplication application, string url)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                application.OpenUrl(NSUrl.FromString(url), new NSDictionary(), null);
            }
            else
            {
                application.OpenUrl(NSUrl.FromString(url));
            }
        }
    }
}
