using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Orders
{
    public class Products
    {
        public string articleordernumber;
        public double price;
        public double priceNet;
        public int quantity;
        public string name;
        public int shipped;
        public string status;
        public string ean;
        public int tax;
    }
}
