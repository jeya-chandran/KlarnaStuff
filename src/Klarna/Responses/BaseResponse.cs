using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Klarna.Responses
{
    public abstract class BaseResponse : IBaseResponse
    {
        public virtual bool IsSuccess
        {
            get
            {
                return (StatusCode >= 200 && StatusCode < 300);
            }
        }

        public virtual int StatusCode { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty(PropertyName = "error_messages")]
        private ICollection<string> ErrorMessages { get; set; }

        public virtual string ErrorMessage
        {
            get
            {
                string errorMessgae = string.Empty;

                if (ErrorMessages != null && ErrorMessages.Count > 0)
                {
                    errorMessgae = String.Join(", ", ErrorMessages.ToArray());
                }

                return (errorMessgae);
            }
        }

        [JsonProperty(PropertyName = "html_snippet")]
        public string HtmlSnippet { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public string KlarnaOrderId { get; set; }
    }
}

