using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Orders
{
    public class MerchantOrder
    {
        public int? id;
        public int ordernumber;
        public bool? ship;
        public double amount;
        public double amountNet;
        public string ordertime;
        public string currency;
        public List<Products> products;
        public Shipping shipping;
    }
}
