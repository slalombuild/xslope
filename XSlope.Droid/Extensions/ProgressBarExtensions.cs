using Android.Graphics.Drawables;
using Android.Widget;
using Android.Content;

namespace XSlope.Droid.Extensions
{
    public static class ProgressBarExtensions
    {
        public static void SetProgressTrackColor(this ProgressBar progressBar, Context context, int colorResource)
        {
            SetColor(progressBar, context, Android.Resource.Id.Progress, colorResource);
        }

        public static void SetBackgroundTrackColor(this ProgressBar progressBar, Context context, int colorResource)
        {
            SetColor(progressBar, context, Android.Resource.Id.Background, colorResource);
        }

        static void SetColor(ProgressBar progressBar, Context context, int layerId, int colorResource)
        {
            var drawable = ((LayerDrawable)progressBar.ProgressDrawable).FindDrawableByLayerId(layerId);
            drawable.SetBackgroundColor(context, colorResource);
        }
    }
}
