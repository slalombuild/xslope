namespace XSlope.Core.Converters
{
    public class ReverseBoolConverter : BaseConverter<bool, bool>
    {
        protected override bool Convert(bool fromValue)
        {
            return !fromValue;
        }
    }
}
