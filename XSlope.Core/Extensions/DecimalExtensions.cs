using System.Globalization;

namespace XSlope.Core.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToAmountWithDollarSignString(this decimal amount)
        {
            return amount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }

        public static string ToAmountWithoutSymbolString(this decimal amount)
        {
            return amount.ToString("N", CultureInfo.InvariantCulture);
        }
    }
}
