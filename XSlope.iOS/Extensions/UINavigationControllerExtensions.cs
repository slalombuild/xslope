using System;
using UIKit;

namespace XSlope.iOS.Extensions
{
    public static class UINavigationControllerExtensions
    {
        public static void RemoveNavigationBarBorder(this UINavigationController viewController)
        {
            viewController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            viewController.NavigationBar.ShadowImage = new UIImage();
        }
    }
}
