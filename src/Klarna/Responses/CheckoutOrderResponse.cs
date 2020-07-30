using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Klarna.Models;
using Newtonsoft.Json;

namespace Klarna.Responses
{
    public class CheckoutOrderResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "merchant_reference1")]
        public string VeritixOrderId { get; set; }
    }
}
