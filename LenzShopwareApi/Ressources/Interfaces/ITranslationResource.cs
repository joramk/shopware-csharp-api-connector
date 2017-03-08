using Lenz.ShopwareApi.Models.Translations;
using System.Collections.Generic;

namespace Lenz.ShopwareApi.Ressources
{
    public interface ITranslationResource
    {
        List<Models.Articles.Translation> getAll(List<KeyValuePair<string, string>> parameters);

        int add(Translation<Models.Articles.Translation> translatedArticle);

        void update(Translation<Models.Articles.Translation> translatedArticle);
    }
}