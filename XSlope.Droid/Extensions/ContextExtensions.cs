using Android.Content;

namespace XSlope.Droid.Extensions
{
    public static class ContextExtensions
    {
        public static void NavigateToUrl(this Context context, string url)
        {
            var uri = Android.Net.Uri.Parse(url);
            var intent = new Intent(Intent.ActionView, uri);
            context.StartActivity(intent);
        }
    }
}
