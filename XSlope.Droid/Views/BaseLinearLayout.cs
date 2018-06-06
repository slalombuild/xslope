using System.ComponentModel;
using System.Runtime.CompilerServices;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using ReactiveUI;
using XSlope.Core.ViewModels;

namespace XSlope.Droid.Views
{
    public abstract class BaseLinearLayout<TViewModel> : LinearLayout, INotifyPropertyChanged, IViewFor<TViewModel> where TViewModel : BaseViewModel
    {
        protected BaseLinearLayout(Context context) : base(context) { Inflate(context); }
        protected BaseLinearLayout(Context context, IAttributeSet attrs) : base(context, attrs) { Inflate(context); }
        protected BaseLinearLayout(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { Inflate(context); }

        protected abstract int ViewLayout { get; }
        protected virtual void FindViews(View view) { }
        protected virtual void SetupViewModelBindings() { }
        protected virtual void SetupViewModelActions() { }
        protected virtual void SetupControls() { }
        protected virtual void StyleControls() { }

        void Inflate(Context context)
        {
            Inflate(context, ViewLayout, this);
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

                    FindViews(this);
                    SetupViewModelBindings();
                    SetupViewModelActions();
                    SetupControls();
                    StyleControls();
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
