using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA.Services
{
    public class KlarnaCreateCheckoutOrderResponse
    {
        public string KlarnaOrderId { get; set; }
        public string KlarnaOrderStatus { get; set; }
        public string HtmlSnippet { get; set; }
        public string ErrorMessage { get; set; }
        public string VeritixOrderId { get; set; }
    }
}
