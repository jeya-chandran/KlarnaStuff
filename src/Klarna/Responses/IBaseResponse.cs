using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Klarna.Responses
{
    public interface IBaseResponse
    {
        bool IsSuccess { get;  }

        /// <summary>
        /// HTTP Status code
        /// </summary>
        int StatusCode { get; set; }

        // Klarna error code returned by the API
        string ErrorCode { get; set; }

        /// <summary>
        /// Klarna error message returned by the API
        /// </summary>
        /// <remarks>
        /// </remarks>
        string ErrorMessage { get;  }
    }
}
