using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Articles
{
    public class Price
    {
        public int? id;
        public int? articleId;
        public int? articleDetailsId;
        public string customerGroupKey;
        public float from;
        public string to;
        public float price;
        public float pseudoPrice;
        public float basePrice;
        public float percent;
    }
}
