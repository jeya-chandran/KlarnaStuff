using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA.Services
{
    public class KlarnaCreateCheckoutOrderRequest
    {
        public int ContextId { get; set; }
        public string OrderId { get; set; }
        public Address BillingAddress { get; set; }
        public Customer Customer { get; set; }
        public int OutletId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string Locale { get; set; }
    }

    public class ShoppingCart
    {
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxRate { get; set; }
    }

    public class Customer
    {
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static Customer Jeya()
        {
            return (new Customer
            {
                AccountNumber = "8138647",
                FirstName = "Jeya",
                LastName = "Chandran"
            });
        }
    }

    public class Address
    {
        #region Property Line1 : string
        public string Line1 { get; set; }
        #endregion

        #region Property Line2 : string
        public string Line2 { get; set; }
        #endregion

        #region Property City : string
        public string City { get; set; }
        #endregion

        #region Property State : string
        public string State { get; set; }
        #endregion

        #region Property Zip : string
        public string Zip { get; set; }
        #endregion

        #region Property Country : string
        public string Country { get; set; }

        public static Address Jeya()
        {
            return (new Address
            {
                Line1 = "115 Malvern Ave",
                Line2 = "Rayners Lane",
                City = "Harrow",
                State = "Middlesex",
                Zip = "HA2 9HA",
                Country = "GB"
            });
        }
        #endregion
    }
}
