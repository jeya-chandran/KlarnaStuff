using System.Collections.Specialized;
using System.Linq;

namespace Klarna
{
    /// <summary>
    /// Url Helper Class.
    /// Contains routines to work with URL and query strings.
    /// </summary>
    internal static class UrlHelper
    {
        /// <summary>
        /// Builds the API URL based on the base & controller urls 
        /// </summary>
        /// <param name="baseUrl">Environment URL (like https://api.klarna.com)</param>
        /// <param name="resourceUrl">Controller URL</param>
        /// <param name="append">URL appendix</param>
        /// <param name="parameters">Extra parameters (will be added as a query string after "?")</param>
        /// <returns>API URL</returns>
        public static string GetApiUrl(string baseUrl,
            string resourceUrl,
            string append = null,
            NameValueCollection parameters = null)
        {
            var controllerUri = $"{baseUrl.TrimEnd('/')}/{resourceUrl.TrimStart('/')}{(!string.IsNullOrEmpty(append) ? $"/{append}" : string.Empty)}";

            if (parameters == null || parameters.Count == 0)
                return controllerUri;

            return $"{controllerUri}{(controllerUri.IndexOf('?') > -1 ? "&" : "?")}{parameters.ToQueryString()}";
        }

        /// <summary>
        /// Converts collection to query URL params
        /// </summary>
        /// <param name="urlParams">Name-Value Collection to convert to query params</param>
        /// <returns>URL query params</returns>
        private static string ToQueryString(this NameValueCollection urlParams)
        {
            return string.Join("&",
                urlParams.AllKeys.Distinct().Select(a => a + "=" + urlParams[a]));
        }
    }
}
