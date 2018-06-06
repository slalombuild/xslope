using System;
using System.Linq;
using Foundation;
using UIKit;

namespace XSlope.iOS.Extensions
{
    public static class UISearchBarExtensions
    {
        public static void SetTextFieldBackgroundColor(this UISearchBar searchBar, UIColor color)
        {
            var backgroundView = searchBar.GetTextField()?.Subviews.FirstOrDefault();
            if (backgroundView == null)
            {
                return;
            }

            foreach (var subview in backgroundView.Subviews)
            {
                subview.RemoveFromSuperview();
            }
            backgroundView.BackgroundColor = color;
            backgroundView.Layer.CornerRadius = 10;
            backgroundView.ClipsToBounds = true;
        }

        public static UITextField GetTextField(this UISearchBar searchBar)
        {
            return searchBar.ValueForKey(new NSString("searchField")) as UITextField;
        }
    }
}
