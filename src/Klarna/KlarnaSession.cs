using System.Net;

namespace Klarna
{
    /// <summary>
    /// Session object for communicating with the Klarna API
    /// </summary>
    public class KlarnaSession : IKlarnaSession
    {
        /// <summary>
        /// The user agent string used when calling the Klarna API
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// The API is accessible through a few different URLS. There are different URLs for testing and for making
        /// live purchases as well as different URLs for depending on if you are based in Europe or in the U.S.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Class for Klarna API Credentials
        /// </summary>
        public IKlarnaCredentials Credentials { get; set; }

        /// <summary>
        /// HTTP proxy settings for the WebRequest class
        /// </summary>
        public WebProxy Proxy { get; set; }
    }
}