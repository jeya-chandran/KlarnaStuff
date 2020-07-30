namespace Klarna
{
    /// <summary>
    /// API resource Urls
    /// </summary>
    internal class ResourceUrls
    {
        /// <summary>
        /// Endpoints for Checkout
        /// </summary>
        public const string Checkout_CreateOrder = "checkout/v3/orders";
        public const string Checkout_RetrieveOrder = "checkout/v3/orders/{order_id}";

        /// <summary>
        /// Endpoints for OrderManagement
        /// </summary>
        public const string OrderManagement_AcknowledgeOrder = "ordermanagement/v1/orders/{order_id}/acknowledge";
        public const string OrderManagement_CreateCapture = "ordermanagement/v1/orders/{order_id}/captures";
    }
}
