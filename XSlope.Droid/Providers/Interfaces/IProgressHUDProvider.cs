using System;
using Android.App;

namespace XSlope.Droid.Providers.Interfaces
{
    public interface IProgressHUDProvider
    {
        void Show(Activity activity);
        void Dismiss(Activity activity = null);
    }
}
