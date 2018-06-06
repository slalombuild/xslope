using XSlope.iOS.ViewControllers;
using STARTER_APP.Core.ViewModels;
using ReactiveUI;
using STARTER_APP.iOS.Helpers;

namespace STARTER_APP.iOS.ViewControllers
{
    public partial class HelloWorldViewController : BaseViewController<HelloWorldViewModel>
    {
        public HelloWorldViewController() : base(nameof(HelloWorldViewController))
        {
        }

        protected override void SetupViewModelBindings()
        {
            base.SetupViewModelBindings();
            this.OneWayBind(ViewModel, vm => vm.Title, v => v.Title);
            this.OneWayBind(ViewModel, vm => vm.GettingStartedText, v => v.GettingStartedLabel.Text);
        }

        protected override void StyleControls()
        {
            base.StyleControls();
            GettingStartedLabel.TextColor = Colors.Blue;
        }
    }
}
