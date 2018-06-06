using System;
using System.Globalization;

namespace XSlope.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToFullDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MMMM dd, yyyy", CultureInfo.InvariantCulture);
        }

        public static string ToShortMonthAndDayString(this DateTime dateTime)
        {
            return dateTime.ToString("MMM. dd", CultureInfo.InvariantCulture);
        }

        public static string ToFullMonthAndDayString(this DateTime dateTime)
        {
            return dateTime.ToString("MMMM dd", CultureInfo.InvariantCulture);
        }

        public static string ToShortMonthDayYearString(this DateTime dateTime)
        {
            return dateTime.ToString("M/d/yy", CultureInfo.InvariantCulture);
        }

        public static string ToHyphenatedYearMonthDayString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}
