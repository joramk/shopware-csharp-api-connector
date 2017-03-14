using Lenz.ShopwareApi.Models.Categories;
using Lenz.ShopwareApi.Models.Suppliers;
using Lenz.ShopwareApi.Models.Taxes;
using System;
using System.Collections.Generic;

namespace Lenz.ShopwareApi.Models.Articles
{
    /// <summary>
    /// ArticleCategory reflects the model used to represent the partial data of a category returned/set with the Article resource
    /// </summary>
    public class ArticleCategory
    {
        public int? id;
        public string name;
    }

    public class ArticleMain
    {
        public int? id;
        public int? mainDetailId;
        public int? supplierId;
        public int? taxId;
        public int? priceGroupId;
        public int? filterGroupId;
        public int? configuratorSetId;

        public string name;
        public string description;
        public string descriptionLong;

        public int? pseudoSales;
        public bool? notification;
        
        public bool? active;
        public bool? highlight;
        public bool? lastStock;
        public bool? crossBundleLook;
        public string template;
        public int? mode;
        public string availableFrom;
        public string availableTo;

        /* seo */
        public String keywords;
        public String metaTitle;
        /* history */
        public String added;
        public String changed;
        /* price */
        public bool? priceGroupActive;

        public List<PropertyValue> propertyValues;
        public ArticleMainDetail mainDetail = new ArticleMainDetail();
        public Supplier supplier;  // = new Supplier();
        public Tax tax;            // = new Tax();
        public PropertyGroup propertyGroup;
        public List<CustomerGroup> customerGroups;
        public List<Image> images;
        public String configuratorSet;
        public List<Link> links;
        public List<Download> downloads;
        public List<ArticleDetail> details;
        public List<SeoCategory> seoCategories;
        public List<ArticleCategory> categories;
        public List<SimilarArticle> similar;
        public List<RelatedArticle> related;
        public Dictionary<String, Translation> translations;
    }
}
