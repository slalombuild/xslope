using Android.App;
using AndroidHUD;
using XSlope.Droid.Providers.Interfaces;

namespace XSlope.Droid.Providers
{
    public class AndProgressHUDProvider : IProgressHUDProvider
    {
        public void Show(Activity activity)
        {
            AndHUD.Shared.Show(activity);
        }

        public void Dismiss(Activity activity = null)
        {
            AndHUD.Shared.Dismiss(activity);
        }
    }
}
