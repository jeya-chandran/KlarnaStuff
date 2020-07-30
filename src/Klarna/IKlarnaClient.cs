using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Klarna.Requests;
using Klarna.Responses;

namespace Klarna
{    
    /// <summary>
    /// A class for HTTP clients used to communicate with the Klarna APIs
    /// </summary>
    public interface IKlarnaClient : IDisposable
    {
        /// <summary>
        /// Creates a new checkout order. 
        /// </summary>
        /// <param name="request">The <see cref="CheckoutOrderRequest"/> object</param>
        /// <returns><see cref="CheckoutOrderResponse"/></returns>
        CheckoutOrderResponse CreateCheckoutOrder(ICheckoutOrderRequest request);

        /// <summary>
        /// Creates a new checkout order asynchronously. 
        /// </summary>
        /// <param name="request">The <see cref="CheckoutOrderRequest"/> object</param>
        /// <returns><see cref="CheckoutOrderResponse"/></returns>
        Task<CheckoutOrderResponse> CreateCheckoutOrderAsync(ICheckoutOrderRequest request);

        /// <summary>
        /// Retrieves an existing checkout order. 
        /// </summary>
        /// <param name="klarnaOrderId">Klarna order id to be retrieved</param>
        /// <returns><see cref="CheckoutOrderResponse"/></returns>
        CheckoutOrderResponse GetCheckoutOrder(string klarnaOrderId);

        /// <summary>
        /// Retrieves an existing checkout order asynchronously. 
        /// </summary>
        /// <param name="klarnaOrderId">Klarna order id to be retrieved</param>
        /// <returns><see cref="CheckoutOrderResponse"/></returns>
        Task<CheckoutOrderResponse> GetCheckoutOrderAsync(string klarnaOrderId);

        /// <summary>
        /// Acknowledge an existing paid order. 
        /// </summary>
        /// <param name="klarnaOrderId">Klarna order id to be acknowledged</param>
        /// <returns><see cref="AcknowledgeOrderResponse"/></returns>
        AcknowledgeOrderResponse AcknowledgeOrder(string klarnaOrderId);

        /// <summary>
        /// Acknowledge an existing paid order. 
        /// </summary>
        /// <param name="klarnaOrderId">Klarna order id to be acknowledged</param>
        /// <returns><see cref="AcknowledgeOrderResponse"/></returns>
        Task<AcknowledgeOrderResponse> AcknowledgeOrderAsync(string klarnaOrderId);

        /// <summary>
        /// Create a capture for an existing paid order. 
        /// </summary>
        /// <param name="request">The <see cref="ICreateCaptureOrderRequest"/> object</param>
        /// <returns><see cref="AcknowledgeOrderResponse"/></returns>
        CreateCaptureOrderResponse CreateCaptureOrder(ICreateCaptureOrderRequest request);

        /// <summary>
        /// Create a capture for an existing paid order. 
        /// </summary>
        /// <param name="request">The <see cref="ICreateCaptureOrderRequest"/> object</param>
        /// <returns><see cref="AcknowledgeOrderResponse"/></returns>
        Task<CreateCaptureOrderResponse> CreateCaptureOrderAsync(ICreateCaptureOrderRequest request);
    }
}
