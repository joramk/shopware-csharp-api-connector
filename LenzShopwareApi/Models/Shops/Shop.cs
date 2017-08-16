using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Shops
{
    public class Locale
    {
        public int? id;
        public string locale;
        public string language;
        public string territory;
    }

    public class Shop
    {
        public int? id;
        public int? mainId;
        public int? categoryId;
        public string name;
        public string title;
        public int position;
        public string host;
        public string basePath;
        public string baseUrl;
        public string hosts;
        public bool secure;
        public bool alwaysSecure;
        public string secureHost;
        public string secureBasePath;
        public int? templateId;
        public bool @default;
        public bool active;
        public bool customerScope;
        public Locale locale;
    }
}
