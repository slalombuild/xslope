using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using ReactiveUI;
using XSlope.Core.Container;
using XSlope.Core.Handlers.Interfaces;
using XSlope.Core.ViewModels;
using XSlope.Droid.Extensions;
using XSlope.Droid.Providers.Interfaces;

namespace XSlope.Droid.Fragments
{
    public abstract class BaseFragment<TViewModel> : Fragment, INotifyPropertyChanged, IAlertHandler, IKeyboardHandler, IProgressHUDHandler, IWebHandler, IViewFor<TViewModel> where TViewModel : BaseViewModel
    {
        ActionBar SupportActionBar => ((AppCompatActivity)Activity).SupportActionBar;
        protected abstract int FragmentLayout { get; }
        protected TViewModel ScreenViewModel => ViewModel as TViewModel;

        protected string Title
        {
            get => SupportActionBar?.Title;
            set
            {
                if (SupportActionBar != null)
                {
                    SupportActionBar.Title = value;
                }
            }
        }

        [AppInject]
        public IProgressHUDProvider ProgressHUDProvider { get; private set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            DependencyContainer.Inject(this);
            RetrieveArguments();

            ViewModel = CreateViewModel();
            ViewModel.AlertHandler = this;
            ViewModel.KeyboardHandler = this;
            ViewModel.ProgressHUDHandler = this;
            ViewModel.WebHandler = this;

            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(FragmentLayout, container, false);
            HasOptionsMenu = true;
            FindViews(view);
            SetupControls();
            SetupViewModelBindings();
            SetupViewModelActions();
            ViewModel?.Start();

            return view;
        }

        protected virtual void FindViews(View view) { }
        protected virtual void RetrieveArguments() { }
        protected virtual TViewModel CreateViewModel() { return DependencyContainer.Get<TViewModel>(); }
        protected virtual void SetupViewModelBindings() { }
        protected virtual void SetupViewModelActions() { }
        protected virtual void SetupControls() { }

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
            Activity?.DisplayAlert(title, message, buttonText);
        }

        #endregion

        #region IKeyboardHandler

        public void DismissKeyboard()
        {
            Activity?.DismissKeyboard();
        }

        #endregion

        #region IProgressHUDHandler

        public void ShowProgressHUD()
        {
            ProgressHUDProvider.Show(Activity);
        }

        public void DismissProgressHUD()
        {
            ProgressHUDProvider.Dismiss(Activity);
        }

        #endregion

        #region IWebHandler

        public void ShowExternalWebPage(string url)
        {
            Activity?.NavigateToUrl(url);
        }

        #endregion
    }
}
