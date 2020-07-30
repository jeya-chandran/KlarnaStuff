using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

using Klarna.Models;
using Klarna.Requests;
using Klarna.Responses;
using Klarna.Serialization;

namespace Klarna
{    
    /// <summary>
    /// A class for HTTP clients used to communicate with the Klarna APIs
    /// </summary>
    public class KlarnaClient : IKlarnaClient
    {
        private bool _isDisposed;
        private readonly RestClient _client;
        private readonly IJsonSerializer _jsonSerializer;

        #region Public properties

        public IKlarnaSession Session { get; set; }

        #endregion Public Properies

        #region Constructors

        private KlarnaClient()
        {
        }

        public KlarnaClient(IKlarnaSession session)
        {
            Session = session;
            _client = CreateRestClient();
            _jsonSerializer = new Klarna.Serialization.JsonSerializer();
        }

        #endregion Constructors

        #region Public methods

        #region IKlarnaClient methods

        /// <summary>
        /// Creates a new checkout order. 
        /// </summary>
        /// <param name="request">The <see cref="ICheckoutOrderRequest"/> object</param>
        /// <returns><see cref="CheckoutOrderResponse"/></returns>
        public virtual CheckoutOrderResponse CreateCheckoutOrder(ICheckoutOrderRequest request)
        {
            var url = UrlHelper.GetApiUrl(Session.BaseUrl, ResourceUrls.Checkout_CreateOrder);

            RestRequest req = CreateRestRequest(Method.POST, url, GetRequestBody(request.OrderData));
            var res = _client.Execute(req);

            var response = DeserializeOrDefault<CheckoutOrderResponse>(res);

            return (response);
        }

        /// <summary>
        /// Creates a new checkout order asynchronously. 
        /// </summary>
        /// <param name="request">The <see cref="ICheckoutOrderRequest"/> object</param>
        /// <returns><see cref="CheckoutOrderResponse"/></returns>
        public virtual async Task<CheckoutOrderResponse> CreateCheckoutOrderAsync(ICheckoutOrderRequest request)
        {
            var url = UrlHelper.GetApiUrl(Session.BaseUrl, ResourceUrls.Checkout_CreateOrder);

            RestRequest req = CreateRestRequest(Method.POST, url, GetRequestBody(request.OrderData));
            var res = await _client.ExecutePostTaskAsync(req).ConfigureAwait(false);

            var response = DeserializeOrDefault<CheckoutOrderResponse>(res);

            return (response);
        }

        /// <summary>
        /// Retrieves an existing checkout order. 
        /// </summary>
        /// <param name="klarnaOrderId">Klarna order id to be retrieved</param>
        /// <returns><see cref="CheckoutOrderResponse"/></returns>
        public virtual CheckoutOrderResponse GetCheckoutOrder(string klarnaOrderId)
        {
            var url = UrlHelper.GetApiUrl(Session.BaseUrl, ResourceUrls.Checkout_RetrieveOrder);
            url = url.Replace("{order_id}", klarnaOrderId);

            RestRequest req = CreateRestRequest(Method.GET, url, null);
            var res = _client.Execute(req);

            var response = DeserializeOrDefault<CheckoutOrderResponse>(res);

            return (response);
        }

        /// <summary>
        /// Retrieves an existing checkout order asynchronously. 
        /// </summary>
        /// <param name="klarnaOrderId">Klarna order id to be retrieved</param>
        /// <returns><see cref="CheckoutOrderResponse"/></returns>
        public virtual async Task<CheckoutOrderResponse> GetCheckoutOrderAsync(string klarnaOrderId)
        {
            var url = UrlHelper.GetApiUrl(Session.BaseUrl, ResourceUrls.Checkout_RetrieveOrder);
            url = url.Replace("{order_id}", klarnaOrderId);

            RestRequest req = CreateRestRequest(Method.GET, url, null);
            var res = await _client.ExecuteGetTaskAsync(req).ConfigureAwait(false);

            var response = DeserializeOrDefault<CheckoutOrderResponse>(res);

            return (response);
        }

        /// <summary>
        /// Acknowledge an existing paid order. 
        /// </summary>
        /// <param name="klarnaOrderId">Klarna order id to be acknowledged</param>
        /// <returns><see cref="AcknowledgeOrderResponse"/></returns>
        public virtual AcknowledgeOrderResponse AcknowledgeOrder(string klarnaOrderId)
        {
            var url = UrlHelper.GetApiUrl(Session.BaseUrl, ResourceUrls.OrderManagement_AcknowledgeOrder);
            url = url.Replace("{order_id}", klarnaOrderId);

            RestRequest req = CreateRestRequest(Method.POST, url, null);
            var res = _client.Execute(req);

            var response = DeserializeOrDefault<AcknowledgeOrderResponse>(res);

            return (response);
        }

        /// <summary>
        /// Acknowledge an existing paid checkout order. 
        /// </summary>
        /// <param name="klarnaOrderId">Klarna order id to be acknowledged</param>
        /// <returns><see cref="AcknowledgeOrderResponse"/></returns>
        public virtual async Task<AcknowledgeOrderResponse> AcknowledgeOrderAsync(string klarnaOrderId)
        {
            var url = UrlHelper.GetApiUrl(Session.BaseUrl, ResourceUrls.OrderManagement_AcknowledgeOrder);
            url = url.Replace("{order_id}", klarnaOrderId);

            RestRequest req = CreateRestRequest(Method.POST, url, null);
            var res = await _client.ExecutePostTaskAsync(req).ConfigureAwait(false);
            
            var response = DeserializeOrDefault<AcknowledgeOrderResponse>(res);

            return (response);
        }

        /// <summary>
        /// Create a capture for an existing paid order. 
        /// </summary>
        /// <param name="request">The <see cref="ICreateCaptureOrderRequest"/> object</param>
        /// <returns><see cref="AcknowledgeOrderResponse"/></returns>
        public virtual CreateCaptureOrderResponse CreateCaptureOrder(ICreateCaptureOrderRequest request)
        {
            var url = UrlHelper.GetApiUrl(Session.BaseUrl, ResourceUrls.OrderManagement_CreateCapture);
            url = url.Replace("{order_id}", request.KlarnaOrderId);

            RestRequest req = CreateRestRequest(Method.POST, url, GetRequestBody(request.CaptureData));
            var res = _client.Execute(req);

            var response = DeserializeOrDefault<CreateCaptureOrderResponse>(res);

            return (response);
        }

        /// <summary>
        /// Create a capture for an existing paid order. 
        /// </summary>
        /// <param name="request">The <see cref="ICreateCaptureOrderRequest"/> object</param>
        /// <returns><see cref="AcknowledgeOrderResponse"/></returns>
        public virtual async Task<CreateCaptureOrderResponse> CreateCaptureOrderAsync(ICreateCaptureOrderRequest request)
        {
            var url = UrlHelper.GetApiUrl(Session.BaseUrl, ResourceUrls.OrderManagement_CreateCapture);
            url = url.Replace("{order_id}", request.KlarnaOrderId);

            RestRequest req = CreateRestRequest(Method.POST, url, GetRequestBody(request.CaptureData));
            var res = await _client.ExecutePostTaskAsync(req).ConfigureAwait(false);

            var response = DeserializeOrDefault<CreateCaptureOrderResponse>(res);

            if (response.IsSuccess && res.Headers.Any(t => t.Name == "Capture-Id"))
            {
                response.CaptureId = res.Headers.ToList()
                                     .Find(x => x.Name == "Capture-Id")
                                     .Value.ToString();
            }

            return (response);
        }

        #endregion IKlarnaClient methods

        #region IDisposable methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The bulk of the clean-up code
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                // free managed resources
            }

            // free native resources if there are any.

            _isDisposed = true;
        }

        #endregion IDisposable methods

        #endregion Public methods

        #region Private methods

        private RestClient CreateRestClient()
        {
            RestClient client;

            client = new RestClient(Session.BaseUrl) { Authenticator = new HttpBasicAuthenticator(Session.Credentials.Username, Session.Credentials.Password) };

            return (client);
        }

        private RestRequest CreateRestRequest(Method method, string url, string body)
        {
            var request = new RestRequest(url, method);

            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(body))
            {
                request.AddParameter("undefined", body, ParameterType.RequestBody);
            }

            return request;
        }

        private string GetRequestBody(object data)
        {
            if (data == null) return null;

            return _jsonSerializer.Serialize(data);
        }

        private T DeserializeOrDefault<T>(IRestResponse response)
        {
            var content = response.Content;
            T obj = string.IsNullOrEmpty(content) ? 
                    _jsonSerializer.Deserialize<T>(_jsonSerializer.Serialize(response)) : 
                    _jsonSerializer.Deserialize<T>(content);

            if (obj is IBaseResponse)
            {
                ((IBaseResponse)obj).StatusCode = (int)response.StatusCode;
            }

            return (obj);
        }

        #endregion Private methods
    }
}
