using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Klarna.Models;

namespace Klarna.Requests
{
    public interface ICreateCaptureOrderRequest
    {
        string KlarnaOrderId { get; set; }

        OrderManagementCreateCapture CaptureData { get; set; }
    }
}
