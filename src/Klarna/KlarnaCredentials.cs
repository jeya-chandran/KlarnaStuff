namespace Klarna
{
    /// <summary>
    /// Class for Klarna API Credentials
    /// </summary>
    public class KlarnaCredentials : IKlarnaCredentials
    {
        /// <summary>
        /// Username
        /// Consists of Merchant ID (eid) - a unique number that identifies your e-store, combined with a random string.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// A string which is associated with your Merchant ID and is used to authorize use of Klarna's APIs
        /// </summary>
        public string Password { get; set; }
    }
}
