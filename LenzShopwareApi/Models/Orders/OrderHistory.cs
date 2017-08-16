using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Orders
{
    public class OrderHistory
    {
        public int? id;
        public int? customerId;
        public Customers.Customer customer;
        public string partnerId;
        public string docDate;
        public int? docType;
        public string docNr;
        public int? docLine;
        public string docRef;
        public string docBcNr;
        public string docBcDate;
        public string docBlNr;
        public string docBlDate;
        public string artRef;
        public string artDescription;
        public int? artQty;
        public float? amount;
        public float? amountNet;
        public float? discount;
    }
}
