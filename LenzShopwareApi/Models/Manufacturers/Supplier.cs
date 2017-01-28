using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Suppliers
{
    public class SupplierAttributes
    {
        public int? id;                     // primary key of s_articles_supplier_attributes
        public int? articleSupplierId;      // link to id in s_articles_supplier

        // properties below are free fields added to the system, adjust as needed
        public string idErp;
    }

    public class Supplier
    {
        public int? id;
        public string name;
        public string image;
        public string link;
        public string description;
        public string metaTitle;
        public string metaDescription;
        public string metaKeywords;
        public string changed;

        public SupplierAttributes attribute;
    }

}
