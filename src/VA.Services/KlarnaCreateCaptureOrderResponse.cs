using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA.Services
{
    public class KlarnaCreateCaptureOrderResponse
    {
        public string CaptureId { get; set; }
        public string KlarnaOrderStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}
