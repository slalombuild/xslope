using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ReactiveUI;
using XSlope.Core.Handlers.Interfaces;

namespace XSlope.Core.ViewModels
{
    public class BaseViewModel : ReactiveObject
    {
        protected BaseViewModel() { }

        public IAlertHandler AlertHandler { get; set; }
        public IKeyboardHandler KeyboardHandler { get; set; }
        public IProgressHUDHandler ProgressHUDHandler { get; set; }
        public IWebHandler WebHandler { get; set; }

        public virtual Task Start()
        {
            return Task.CompletedTask;
        }

        protected void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            this.RaiseAndSetIfChanged(ref backingField, value, propertyName);
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            this.RaisePropertyChanged(propertyName);
        }
    }
}
