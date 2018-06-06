using Android.App;
using Android.Content;
using Android.Views.InputMethods;

namespace XSlope.Droid.Extensions
{
    public static class ActivityExtensions
    {
        #region Alerts

        public static void DisplayAlert(this Activity activity, string title, string message, string buttonText = null)
        {
            buttonText = buttonText ?? "OK";

            new AlertDialog.Builder(activity)
                           .SetCancelable(false)
                           .SetTitle(title)
                           .SetMessage(message)
                           .SetNeutralButton(buttonText, (dialog, button) => { })
                           .Show();
        }

        public static void DismissKeyboard(this Activity activity)
        {
            if (activity.CurrentFocus != null)
            {
                var imm = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);
            }
        }

        #endregion
    }
}
