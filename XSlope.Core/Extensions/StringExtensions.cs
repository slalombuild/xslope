using System.Web;

namespace XSlope.Core.Extensions
{
    public static class StringExtensions
    {
        public static string AddQueryParam(this string url, string name, string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
            {
                return url;
            }

            var query = HttpUtility.ParseQueryString(string.Empty);
            query[name] = value;

            var separator = url.Contains("?") ? "&" : "?";

            return string.Format("{0}{1}{2}", url, separator, query);
        }
    }
}
