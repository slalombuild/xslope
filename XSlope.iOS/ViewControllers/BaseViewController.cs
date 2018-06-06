using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Foundation;
using ReactiveUI;
using UIKit;
using XSlope.Core.Container;
using XSlope.Core.Handlers.Interfaces;
using XSlope.Core.ViewModels;
using XSlope.iOS.Extensions;
using XSlope.iOS.Handlers.Interfaces;
using XSlope.iOS.Providers.Interfaces;

namespace XSlope.iOS.ViewControllers
{
    public abstract class BaseViewController<TViewModel> : UIViewController, INotifyPropertyChanged, IAlertHandler, IKeyboardHandler, IProgressHUDHandler, IWebHandler, IScreenNavigationHandler, IViewFor<TViewModel> where TViewModel : BaseViewModel
    {
        [AppInject]
        IProgressHUDProvider ProgressHUDProvider { get; set; }

        protected BaseViewController(string nibName, NSBundle bundle = null) : base(nibName, bundle)
        {
            EdgesForExtendedLayout = UIRectEdge.None;
        }

        public override void ViewDidLoad()
        {
            DependencyContainer.Inject(this);

            this.HideBackButtonText();

            if (ShouldScrollVertically)
            {
                this.MakeScrollable(BackgroundColor);
            }

            ViewModel = CreateViewModel();
            ViewModel.AlertHandler = this;
            ViewModel.KeyboardHandler = this;
            ViewModel.ProgressHUDHandler = this;
            ViewModel.WebHandler = this;

            View.BackgroundColor = BackgroundColor;

            SetupViewModelBindings();
            SetupViewModelActions();
            SetupControls();
            StyleControls();

            ViewModel.Start();

            base.ViewDidLoad();
        }

        protected virtual bool ShouldScrollVertically => false;
        protected virtual UIColor BackgroundColor => UIColor.White;

        protected virtual TViewModel CreateViewModel() { return DependencyContainer.Get<TViewModel>(); }
        protected virtual void SetupViewModelBindings() { }
        protected virtual void SetupViewModelActions() { }
        protected virtual void SetupControls() { }
        protected virtual void StyleControls() { }
        protected virtual void SetupNavigationBar() { }

        #region IViewFor

        TViewModel _viewModel;
        public TViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        object IViewFor.ViewModel
        {
            get => _viewModel;
            set { ViewModel = (TViewModel)value; }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IAlertHandler

        public void ShowAlert(string title, string message, string buttonText = null)
        {
            this.DisplayAlert(title, message, buttonText);
        }

        #endregion

        #region IKeyboardHandler

        public void DismissKeyboard()
        {
            View?.EndEditing(true);
        }

        #endregion

        #region IProgressHUDHandler

        public void ShowProgressHUD()
        {
            ProgressHUDProvider?.Show();
        }

        public void DismissProgressHUD()
        {
            ProgressHUDProvider?.Dismiss();
        }

        #endregion

        #region IWebHandler

        public void ShowExternalWebPage(string url)
        {
            UIApplication.SharedApplication.NavigateToUrl(url);
        }

        #endregion

        #region IScreenPresentationHandler

        public void Present(UIViewController viewController, bool animated = true, Action onComplete = null)
        {
            PresentViewController(viewController, animated, onComplete);
        }

        public void Push(UIViewController viewController, bool animated = true)
        {
            NavigationController?.PushViewController(viewController, animated);
        }

        #endregion

    }
}
