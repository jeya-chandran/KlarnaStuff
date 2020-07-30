using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klarna
{    
    /// <summary>
    /// Interface for Klarna API Credentials
    /// </summary>
    public interface IKlarnaCredentials
    {
        /// <summary>
        /// Username
        /// Consists of Merchant ID (eid) - a unique number that identifies your e-store, combined with a random string.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Password
        /// A string which is associated with your Merchant ID and is used to authorize use of Klarna's APIs
        /// </summary>
        string Password { get; set; }
    }
}
