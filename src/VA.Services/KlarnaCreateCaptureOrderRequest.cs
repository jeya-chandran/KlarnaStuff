using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA.Services
{
    public class KlarnaCreateCaptureOrderRequest
    {
        public string KlarnaOrderId { get; set; }

        public decimal CapturedAmount { get; set; }

        public string Description { get; set; }
    }
}
