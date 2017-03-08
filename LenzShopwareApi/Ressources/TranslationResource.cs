using Lenz.ShopwareApi.Models.Translations;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Lenz.ShopwareApi.Ressources
{
    public class ArticleTranslationResource : SuperRessource<Translation<Models.Articles.Translation>>, ITranslationResource
    {
        public ArticleTranslationResource(IRestClient client)
            : base(client)
        {
            ressourceUrl = "translations";
        }

        public new int add(Translation<Models.Articles.Translation> translatedArticle)
        {
            if (translatedArticle.key != null &&
                !string.IsNullOrEmpty(translatedArticle.type) &&
                translatedArticle.shopId != null)
            {
                ApiPostResponse response = base.add(translatedArticle);
                return response.id.GetValueOrDefault();
            }
            throw new ArgumentException("'key', 'type' and 'shopId' are required for adding a translation");
        }

        public List<Models.Articles.Translation> getAll(List<KeyValuePair<string, string>> parameters)
        {
            throw new NotImplementedException();
        }

        public new void update(Translation<Models.Articles.Translation> translatedArticle)
        {
            if (translatedArticle.key != null &&
                !string.IsNullOrEmpty(translatedArticle.type) &&
                translatedArticle.shopId != null)
            {
                int i = translatedArticle.key.GetValueOrDefault();
                translatedArticle.key = null;                           // hide this field in json update data
                base.executeUpdate(translatedArticle, i.ToString());
            }
            throw new ArgumentException("'key', 'type' and 'shopId' are required for updating a translation");
        }
    }
}
