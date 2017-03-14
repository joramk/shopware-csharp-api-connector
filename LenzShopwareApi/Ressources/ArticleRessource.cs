using Lenz.ShopwareApi.Models.Articles;
using RestSharp;
using System;

namespace Lenz.ShopwareApi.Ressources
{
    public class ArticleRessource : SuperRessource<ArticleMain>, IArticleRessource
    {
        public ArticleRessource(IRestClient client)
            : base (client)
        {
            ressourceUrl = "articles";
        }

        public new int add(ArticleMain article)
        {
            if (article.name != null
                && article.mainDetail.number != null
                && (article.supplierId!=null || article.supplier != null)
                && (article.taxId != null || article.tax != null ))
            {
                ApiPostResponse response = base.add(article);
                return response.id.GetValueOrDefault();
            }
            throw new ArgumentException("Minimum required fields for article add: article.name, article.mainDetail.number, article.supplier or article.supplierId, article.tax or article.taxId");
        }

        new public void update(ArticleMain article)
        {
            if(article.id != null)
            {
                if (article.mainDetail.id == null)
                {
                    article.mainDetail = null;          // remove complete detail from update
                }
                base.executeUpdate(article, article.id.ToString());
                return;
            }
            throw new Exception("Minimum required fields for article update: article.id");
        }

        /// <summary>
        /// With this function it is possible to request an article by ordernumber
        /// </summary>
        /// <param name="ordernumber"></param>
        /// <returns></returns>
        public ArticleMain getByOrdernumber(string ordernumber)
        {
            return this.get(ordernumber, true);
        }
    }
}
