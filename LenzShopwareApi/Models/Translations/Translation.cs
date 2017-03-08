using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Translations
{
    public class Translation<T>
    {
        public int? key;
        public string type;
        public int? shopId;
        public T data;

        public Translation(int iShop, int key2translate)
        {
            shopId = iShop;
            key = key2translate;
            if (typeof(T) == typeof(Articles.Translation))
                type = "article";
        }

    }

    
}
