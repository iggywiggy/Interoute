using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace InterouteWebAPI.Common
{
    public class Utils
    {
        public static string GetStringQueryParameters(Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            var parameters = HttpUtility.ParseQueryString(uri.Query);

            var stringBuilder = new StringBuilder();

            foreach (string key in parameters)
                stringBuilder.Append("" + parameters[key]);

            return stringBuilder.ToString();
        }

        public static bool ConvertStringToInt(string toBeConverted, out long converted)
        {
            if (string.IsNullOrEmpty(toBeConverted))
                throw new ArgumentNullException(nameof(toBeConverted));

            return long.TryParse(toBeConverted.Trim(), NumberStyles.Any, new CultureInfo("en-GB", false),
                out converted);
        }
    }
}