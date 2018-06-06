using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using XSlope.Core.Container;
using XSlope.Core.Handlers.Interfaces;
using XSlope.Core.Managers.Interfaces;
using XSlope.Core.ViewModels;
using XSlope.Droid.Fragments;

namespace XSlope.Droid.Activities
{
    [Activity(Label = "Base Activity")]
    public abstract class BaseActivity : AppCompatActivity, IAuthenticationHandler
    {
        [AppInject]
        public IAuthenticationManager AuthenticationManager { get; set; }

        protected virtual int Layout => Resource.Layout.BaseActivity;

        protected virtual int? CustomActivityLayout => null;

        protected virtual bool DisplaySupportActionBar => true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            DependencyContainer.Inject(this);

            AuthenticationManager.AuthenticationHandler = this;

            SetContentView(Layout);
            InflateCustomActivityLayout();

            RetrieveExtras();

            ConfigureFragments();
            ConfigureBaseSupportActionBar();
        }

        public void FinishWithResult(Result result)
        {
            SetResult(result);
            Finish();
        }

        public override bool OnSupportNavigateUp()
        {
            base.OnBackPressed();
            return true;
        }

        protected virtual bool DisplaysUpArrow => false;

        protected virtual void RetrieveExtras() { }

        protected virtual void ConfigureFragments() { }

        protected virtual void FindViews(View view) { }

        protected T FindFragment<T>(int containerId) where T : class
        {
            return SupportFragmentManager.FindFragmentById(containerId) as T;
        }

        protected void AddFragment<T>(BaseFragment<T> fragment, int containerId) where T : BaseViewModel
        {
            SupportFragmentManager.BeginTransaction().Add(containerId, fragment).Commit();
        }

        protected void ReplaceFragment<T>(BaseFragment<T> fragment, int containerId) where T : BaseViewModel
        {
            SupportFragmentManager.BeginTransaction().Replace(containerId, fragment)
                                  .SetTransition((int)FragmentTransit.FragmentOpen)
                                  .AddToBackStack(null)
                                  .Commit();
        }

        protected virtual void ConfigureBaseSupportActionBar()
        {
            var supportActionBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.action_bar);
            SetSupportActionBar(supportActionBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(DisplaysUpArrow);

            if (!DisplaySupportActionBar)
            {
                SupportActionBar.Hide();
            }
        }

        void InflateCustomActivityLayout()
        {
            if (CustomActivityLayout.HasValue)
            {
                var screenContainer = FindViewById<FrameLayout>(Resource.Id.screen_container);
                var view = LayoutInflater.Inflate(CustomActivityLayout.Value, screenContainer, true);

                FindViews(view);
            }
        }

        #region IAuthenticationHandler

        public virtual void OnSignIn() { }

        public virtual void OnSignOut() { }

        public virtual void OnTokenExpired() { }

        #endregion
    }
}
