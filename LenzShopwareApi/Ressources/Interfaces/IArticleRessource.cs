using Lenz.ShopwareApi.Models.Articles;
using System.Collections.Generic;

namespace Lenz.ShopwareApi.Ressources
{
    public interface IArticleRessource
    {
        List<ArticleMain> getAll();

        ArticleMain get(int id);

        ArticleMain get(string id);

        ArticleMain getByOrdernumber(string ordernumber);

        /// <summary>
        /// Add article to the shop
        /// </summary>
        /// <param name="article">the article to add</param>
        /// <returns>the "id" of the created article, 0 if it failed</returns>
        int add(ArticleMain article);

        void update(ArticleMain article);
    }
}