using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Foundation;
using ObjCRuntime;
using ReactiveUI;
using UIKit;
using XSlope.Core.Container;
using XSlope.Core.ViewModels;
using XSlope.iOS.Extensions;
using XSlope.iOS.Handlers.Interfaces;

namespace XSlope.iOS.Views
{
    public abstract class BaseView<TViewModel> : UIView, INotifyPropertyChanged, IViewFor<TViewModel> where TViewModel : BaseViewModel
    {
        UIView _view;

        protected BaseView()
        {
            Initialize();
        }

        protected BaseView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        public IScreenNavigationHandler ScreenPresentationHandler { get; set; }
        protected virtual string NibName => GetType().Name;
        protected virtual void SetupViewModelBindings() { }
        protected virtual void SetupViewModelActions() { }
        protected virtual void SetupControls() { }
        protected virtual void StyleControls() { }
        protected virtual void SetupAccessibility() { }
        protected virtual void SetupAccessibilityIds() { }

        void Initialize()
        {
            DependencyContainer.Inject(this);

            var nib = NSBundle.MainBundle.LoadNib(NibName, this, null);
            _view = Runtime.GetNSObject(nib.ValueAt(0)) as UIView;
            AddSubview(_view);
            _view.AddConstraintsToFillSuperview();
        }

        public new UIColor BackgroundColor
        {
            get => _view.BackgroundColor;
            set => _view.BackgroundColor = value;
        }

        protected void PresentViewController(UIViewController viewController, bool animated = true, Action onComplete = null)
        {
            ScreenPresentationHandler?.Present(viewController, animated, onComplete);
        }

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
                    SetupViewModelBindings();
                    SetupViewModelActions();
                    SetupControls();
                    StyleControls();
                    SetupAccessibility();
                    SetupAccessibilityIds();
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
    }
}
