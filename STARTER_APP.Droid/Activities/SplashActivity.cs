using System;
using Android.App;
using Android.OS;

namespace STARTER_APP.Droid.Activities
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Handle any logic determine what activity to start here (ie: are you authenticated or not)
            var intent = HelloWorldActivity.NewIntent(this);
            StartActivity(intent);
            Finish();
        }
    }
}
