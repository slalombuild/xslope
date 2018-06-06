using Android.Views;
using XSlope.Core.Converters;

namespace XSlope.Droid.Converters
{
    public class IsGoneConverter : BaseConverter<bool, ViewStates>
    {
        protected override ViewStates Convert(bool fromValue)
        {
            return fromValue ? ViewStates.Gone : ViewStates.Visible;
        }
    }
}
