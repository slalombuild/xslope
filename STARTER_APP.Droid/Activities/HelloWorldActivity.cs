using System;
using Android.App;
using Android.Content;
using STARTER_APP.Droid.Fragments;
using XSlope.Droid.Activities;
using XSlope.Droid.Extensions;

namespace STARTER_APP.Droid.Activities
{
    [Activity(Label = "HelloWorldActivity")]
    public class HelloWorldActivity : BaseActivity
    {
        public static Intent NewIntent(Context context)
        {
            var intent = new Intent(context, typeof(HelloWorldActivity));
            intent.AddClearBackstackFlags();
            return intent;
        }

        protected override void ConfigureFragments()
        {
            var fragment = FindFragment<HelloWorldFragment>(Resource.Id.screen_container);
            if (fragment == null)
            {
                fragment = HelloWorldFragment.NewInstance();
                AddFragment(fragment, Resource.Id.screen_container);
            }
        }
    }
}
