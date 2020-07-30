using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Klarna.Responses
{
    public class CreateCaptureOrderResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "Capture-Id")]
        public string CaptureId { get; set; }
    }
}
