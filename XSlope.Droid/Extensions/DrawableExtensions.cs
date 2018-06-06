using Android.Graphics.Drawables;
using Android.Content;
using Android.Support.V4.Content;
using Android.Graphics;

namespace XSlope.Droid.Extensions
{
    public static class DrawableExtensions
    {
        public static void SetBackgroundColor(this Drawable drawable, Context context, int colorResource)
        {
            int colorARGB = ContextCompat.GetColor(context, colorResource);
            var color = new Color(colorARGB);

            drawable.SetColorFilter(color, PorterDuff.Mode.SrcIn);
        }
    }
}
