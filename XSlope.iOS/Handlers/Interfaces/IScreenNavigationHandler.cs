using System;
using UIKit;

namespace XSlope.iOS.Handlers.Interfaces
{
    public interface IScreenNavigationHandler
    {
        void Present(UIViewController viewController, bool animated = true, Action onComplete = null);
        void Push(UIViewController viewController, bool animated = true);
    }
}
