using UIKit;

namespace XSlope.iOS.Extensions
{
    public static class UIViewControllerExtensions
    {
        public static void AddChildViewControllerToPlaceHolderView(this UIViewController parentViewController, UIViewController childViewController, UIView starter_appView)
        {
            if (childViewController != null && starter_appView != null)
            {
                parentViewController.AddChildViewController(childViewController);
                starter_appView.AddSubview(childViewController.View);
                childViewController.View.AddConstraintsToFillSuperview();
                childViewController.DidMoveToParentViewController(parentViewController);
            }
        }

        public static void RemoveFromSuperViewController(this UIViewController viewController)
        {
            viewController.WillMoveToParentViewController(null);
            viewController.View.RemoveFromSuperview();
            viewController.RemoveFromParentViewController();
        }

        public static void HideBackButtonText(this UIViewController viewController)
        {
            if (viewController.NavigationItem != null)
            {
                var backButtonItem = new UIBarButtonItem(string.Empty, UIBarButtonItemStyle.Plain, null);
                viewController.NavigationItem.BackBarButtonItem = backButtonItem;
            }
        }

        public static UITableView CreateTableView(this UIViewController viewController, IUITableViewDataSource tableViewDatasource = null, IUITableViewDelegate tableViewDelegate = null)
        {
            var tableView = new UITableView();
            viewController.View.AddSubview(tableView);
            tableView.AddConstraintsToFillSuperview();

            tableView.DataSource = tableViewDatasource ?? viewController as IUITableViewDataSource;
            tableView.Delegate = tableViewDelegate ?? viewController as IUITableViewDelegate;

            return tableView;
        }

        /// <summary>
        /// Eliminates the needs to implement the UIScrollView in the xib.
        /// You can build out the screens as necessary, then call this method to
        /// wrap the view in a scroll view. 
        /// 
        /// NOTE: The controls in the xib MUST have top to bottom constraints in 
        /// order for the scroll view to determine it's vertical content size.
        /// Usually, this can be done by adding a ">= NUM" constraint on the last
        /// control to the superview's bottom.
        /// </summary>
        public static void MakeScrollable(this UIViewController viewController, UIColor backgroundColor)
        {
            var contentView = viewController.View;
            contentView.BackgroundColor = backgroundColor;
            var newView = new UIView { BackgroundColor = backgroundColor };
            var scrollView = new UIScrollView();

            newView.AddSubview(scrollView);
            scrollView.AddConstraintsToFillSuperview();

            scrollView.AddSubview(contentView);
            contentView.AddConstraintsToFillSuperview();

            contentView.WidthAnchor.ConstraintEqualTo(newView.WidthAnchor).Active = true;

            viewController.View = newView;
        }


        public static void DisplayAlert(this UIViewController viewController, string title, string message, string buttonText = null)
        {
            var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            buttonText = buttonText ?? "OK";
            alertController.AddAction(UIAlertAction.Create(buttonText, UIAlertActionStyle.Default, null));
            viewController.PresentViewController(alertController, true, null);
        }
    }
}
