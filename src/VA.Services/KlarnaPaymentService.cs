using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

using Klarna;
using Klarna.Requests;
using Klarna.Models;

namespace VA.Services
{
    public class KlarnaPaymentService : IKlarnaPaymentService
    {
        private readonly KlarnaClient _client;
        private readonly Context _context;

        #region Constructors

        public KlarnaPaymentService(Context context)
        {
            _context = context;
            _client = CreateKlarnaClient();
        }

        #endregion Constructors

        #region Public methods

        public KlarnaCreateCheckoutOrderResponse CreateKlarnaCheckoutOrder(KlarnaCreateCheckoutOrderRequest request)
        {
            var res = _client.CreateCheckoutOrder(MakeCheckoutOrderRequest(request));

            KlarnaCreateCheckoutOrderResponse response = new KlarnaCreateCheckoutOrderResponse
            {
                KlarnaOrderId = res.KlarnaOrderId,
                VeritixOrderId = res.VeritixOrderId,
                HtmlSnippet = res.HtmlSnippet,
                ErrorMessage = res.ErrorMessage,
                KlarnaOrderStatus = res.IsSuccess ? "Created" : "Failed"
            };

            return (response);
        }

        public async Task<KlarnaCreateCheckoutOrderResponse> CreateKlarnaCheckoutOrderAsync(KlarnaCreateCheckoutOrderRequest request)
        {
            var res = await _client.CreateCheckoutOrderAsync(MakeCheckoutOrderRequest(request));

            KlarnaCreateCheckoutOrderResponse response = new KlarnaCreateCheckoutOrderResponse
            {
                KlarnaOrderId = res.KlarnaOrderId,
                VeritixOrderId = res.VeritixOrderId,
                HtmlSnippet = res.HtmlSnippet,
                ErrorMessage = res.ErrorMessage,
                KlarnaOrderStatus = res.IsSuccess  ? "Created" : "Failed"
            };

            return (response);
        }

        public KlarnaCreateCheckoutOrderResponse GetKlarnaCheckoutOrder(string orderId)
        {
            var res = _client.GetCheckoutOrder(orderId);

            KlarnaCreateCheckoutOrderResponse response = new KlarnaCreateCheckoutOrderResponse
            {
                KlarnaOrderId = res.KlarnaOrderId,
                VeritixOrderId = res.VeritixOrderId,
                HtmlSnippet = res.HtmlSnippet,
                ErrorMessage = res.ErrorMessage,
                KlarnaOrderStatus = res.IsSuccess ? "Retrieved" : "Failed"
            };

            return (response);
        }

        public async Task<KlarnaCreateCheckoutOrderResponse> GetKlarnaCheckoutOrderAsync(string orderId)
        {
            var res = await _client.GetCheckoutOrderAsync(orderId);

            KlarnaCreateCheckoutOrderResponse response = new KlarnaCreateCheckoutOrderResponse
            {
                KlarnaOrderId = res.KlarnaOrderId,
                VeritixOrderId = res.VeritixOrderId,
                HtmlSnippet = res.HtmlSnippet,
                ErrorMessage = res.ErrorMessage,
                KlarnaOrderStatus = res.IsSuccess ? "Retrieved" : "Failed"
            };

            return (response);
        }

        public KlarnaAcknowledgeOrderResponse AcknowledgeKlarnaOrder(string orderId)
        {
            var res = _client.AcknowledgeOrder(orderId);

            KlarnaAcknowledgeOrderResponse response = new KlarnaAcknowledgeOrderResponse
            {
                ErrorMessage = res.ErrorMessage,
                KlarnaOrderStatus = res.IsSuccess ? "Acknowledged" : "Failed"
            };

            return (response);
        }

        public async Task<KlarnaAcknowledgeOrderResponse> AcknowledgeKlarnaOrderAsync(string orderId)
        {
            var res = await _client.AcknowledgeOrderAsync(orderId);

            KlarnaAcknowledgeOrderResponse response = new KlarnaAcknowledgeOrderResponse
            {
                ErrorMessage = res.ErrorMessage,
                KlarnaOrderStatus = res.IsSuccess ? "Acknowledged" : "Failed"
            };

            return (response);
        }

        public KlarnaCreateCaptureOrderResponse CreateKlarnaCaptureOrder(KlarnaCreateCaptureOrderRequest request)
        {
            var res = _client.CreateCaptureOrder(MakeCaptureOrderRequest(request));

            KlarnaCreateCaptureOrderResponse response = new KlarnaCreateCaptureOrderResponse
            {
                CaptureId = res.CaptureId,
                ErrorMessage = res.ErrorMessage,
                KlarnaOrderStatus = res.IsSuccess ? "Created" : "Failed"
            };

            return (response);
        }

        public async Task<KlarnaCreateCaptureOrderResponse> CreateKlarnaCaptureOrderAsync(KlarnaCreateCaptureOrderRequest request)
        {
            var res = await _client.CreateCaptureOrderAsync(MakeCaptureOrderRequest(request));

            KlarnaCreateCaptureOrderResponse response = new KlarnaCreateCaptureOrderResponse
            {
                CaptureId = res.CaptureId,
                ErrorMessage = res.ErrorMessage,
                KlarnaOrderStatus = res.IsSuccess ? "Created" : "Failed"
            };

            return (response);

        }

        #endregion Public methods

        #region Private methods
        private KlarnaClient CreateKlarnaClient()
        {
            IKlarnaCredentials credentials = new KlarnaCredentials
            {
                Username = _context.Properties["Klarna.MerchantId"],
                Password = _context.Properties["Klarna.Password"],
            };

            IKlarnaSession session = new KlarnaSession()
            {
                BaseUrl = _context.Properties["Klarna.BaseUrl"],
                Credentials = credentials,
                Proxy = null
            };

            KlarnaClient client = new KlarnaClient(session);

            return (client);
        }

        private CheckoutOrderRequest MakeCheckoutOrderRequest(KlarnaCreateCheckoutOrderRequest request)
        {
            var ci = new CultureInfo(request.Locale);
            var ri = new RegionInfo(ci.LCID);

            CheckoutOrderRequest req = new CheckoutOrderRequest
            {
                OrderData = new CheckoutOrder
                {
                    Locale = request.Locale.ToLower(),
                    PurchaseCountry = ri.Name.ToLower(),
                    PurchaseCurrency = ri.ISOCurrencySymbol.ToLower(),

                    MerchantReference1 = request.OrderId,
                    OrderAmount = int.Parse(request.ShoppingCart.Total.ToString("0.00").Replace(".", "").Replace(",", "")),
                    OrderTaxAmount = int.Parse(request.ShoppingCart.Tax.ToString("0.00").Replace(".", "").Replace(",", "")),

                    OrderLines = new List<OrderLine>()
                    {
                        new OrderLine
                        {
                            Name = "Tickets",
                            Quantity = 1,
                            UnitPrice = int.Parse(request.ShoppingCart.Total.ToString("0.00").Replace(".", "").Replace(",", "")),
                            TaxRate = int.Parse(request.ShoppingCart.TaxRate.ToString("0.00").Replace(".", "").Replace(",", "")),
                            TotalAmount = int.Parse(request.ShoppingCart.Total.ToString("0.00").Replace(".", "").Replace(",", "")),
                            TotalTaxAmount = int.Parse(request.ShoppingCart.Tax.ToString("0.00").Replace(".", "").Replace(",", "")),
                            TotalDiscountAmount = 0,
                        }
                    },

                    MerchantUrls = new CheckoutMerchantUrls
                    {
                        Terms = _context.Properties["Klarna.MerchantUrl.Terms"],
                        Checkout = _context.Properties["Klarna.MerchantUrl.Checkout"],
                        Confirmation = _context.Properties["Klarna.MerchantUrl.Confirmation"],
                        Push = _context.Properties["Klarna.MerchantUrl.Push"]
                    },

                    CheckoutOptions = new CheckoutOptions
                    {
                        AllowSeparateShippingAddress = false,
                        //ColorButton = "#FF9900",
                        //ColorButtonText = "#FF9900",
                        //ColorCheckbox = "#FF9900",
                        //ColorCheckboxCheckmark = "#FF9900",
                        //ColorHeader = "#FF9900",
                        //ColorLink = "#FF9900",
                        //DateOfBirthMandatory = false,
                        //ShippingDetails = "bar",
                        //AllowedCustomerTypes = new List<string>() { "person", "organization" }
                    },

                    BillingCheckoutAddress = new CheckoutAddressInfo
                    {
                        StreetAddress = "My StreetAddress",
                        StreetAddress2 = "My StreetAddress2",
                        StreetName = "My StreetName",
                        City = "My City",
                        Country =  "SE",
                    }
                }
            };

            return (req);
        }

        private CreateCaptureOrderRequest MakeCaptureOrderRequest(KlarnaCreateCaptureOrderRequest request)
        {
            CreateCaptureOrderRequest req = new CreateCaptureOrderRequest
            {
                KlarnaOrderId = request.KlarnaOrderId,

                CaptureData = new OrderManagementCreateCapture
                { 
                    CapturedAmount = int.Parse(request.CapturedAmount.ToString("0.00").Replace(".", "").Replace(",", "")),
                    Description = request.Description
                }
            };

            return (req);
        }

        #endregion Private methods
    }
}
