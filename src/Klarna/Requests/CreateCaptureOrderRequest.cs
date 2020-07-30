using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Klarna.Models;

namespace Klarna.Requests
{
    public class CreateCaptureOrderRequest : ICreateCaptureOrderRequest
    {
        public string KlarnaOrderId { get; set; }

        public OrderManagementCreateCapture CaptureData { get; set; }
    }
}
