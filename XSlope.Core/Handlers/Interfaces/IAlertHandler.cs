namespace XSlope.Core.Handlers.Interfaces
{
    public interface IAlertHandler
    {
        void ShowAlert(string title, string message, string buttonText = null);
    }
}
