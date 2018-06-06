using System;
using ReactiveUI;
using STARTER_APP.Core.ViewModels;
using XSlope.Droid.Fragments;
using Android.Widget;
using XSlope.Droid.Extensions;

namespace STARTER_APP.Droid.Fragments
{
    public class HelloWorldFragment : BaseFragment<HelloWorldViewModel>
    {
        TextView _gettingStartedTextView;

        public static HelloWorldFragment NewInstance()
        {
            return new HelloWorldFragment();
        }

        protected override int FragmentLayout => Resource.Layout.HelloWorldFragment;

        protected override void FindViews(Android.Views.View view)
        {
            base.FindViews(view);
            view.FindView(ref _gettingStartedTextView, Resource.Id.getting_started_text);
        }

        protected override void SetupViewModelBindings()
        {
            base.SetupViewModelBindings();
            this.OneWayBind(ViewModel, vm => vm.Title, v => v.Title);
            this.OneWayBind(ViewModel, vm => vm.GettingStartedText, v => v._gettingStartedTextView.Text);
        }
    }
}
