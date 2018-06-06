using Android.Widget;

namespace XSlope.Droid.Extensions
{
    public static class LinearLayoutExtensions
    {
        public static void ClearSubViews(this LinearLayout linearLayout)
        {
            linearLayout.RemoveAllViews();
            linearLayout.Invalidate();
        }
    }
}
