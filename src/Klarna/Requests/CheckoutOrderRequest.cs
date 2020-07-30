using System;
using RestSharp.Serializers;

using Klarna.Models;

namespace Klarna.Requests
{
    public class CheckoutOrderRequest : ICheckoutOrderRequest
    {
        public CheckoutOrder OrderData { get; set; }
    }
}
