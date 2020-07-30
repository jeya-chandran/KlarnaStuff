using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA.Services
{
    public interface IKlarnaPaymentService
    {
        KlarnaCreateCheckoutOrderResponse CreateKlarnaCheckoutOrder(KlarnaCreateCheckoutOrderRequest request);
        Task<KlarnaCreateCheckoutOrderResponse> CreateKlarnaCheckoutOrderAsync(KlarnaCreateCheckoutOrderRequest request);

        KlarnaCreateCheckoutOrderResponse GetKlarnaCheckoutOrder(string orderId);
        Task<KlarnaCreateCheckoutOrderResponse> GetKlarnaCheckoutOrderAsync(string orderId);

        KlarnaAcknowledgeOrderResponse AcknowledgeKlarnaOrder(string orderId);
        Task<KlarnaAcknowledgeOrderResponse> AcknowledgeKlarnaOrderAsync(string orderId);

        KlarnaCreateCaptureOrderResponse CreateKlarnaCaptureOrder(KlarnaCreateCaptureOrderRequest request);
        Task<KlarnaCreateCaptureOrderResponse> CreateKlarnaCaptureOrderAsync(KlarnaCreateCaptureOrderRequest request);
    }
}
