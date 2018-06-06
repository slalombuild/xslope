using Android.Views;
using XSlope.Core.Converters;

namespace XSlope.Droid.Converters
{
    public class IsVisibleConverter : BaseConverter<bool, ViewStates>
    {
        protected override ViewStates Convert(bool fromValue)
        {
            return fromValue ? ViewStates.Visible : ViewStates.Gone;
        }
    }
}
