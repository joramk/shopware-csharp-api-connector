using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using Lenz.ShopwareApi.Ressources;
using RestSharp.Authenticators;

namespace Lenz.ShopwareApi
{
    public class ShopwareApi
    {
        private string url;
        private string username;
        private string password;
        private RestClient client;

        private ArticleRessource articleRessource;
        private CategoryRessource categoryRessource;
        private OrderResource orderResource;
        private ManufacturerResource manufacturerResource;
        private MediaResource mediaResource;
        private CustomerResource customerResource;
        private ArticleTranslationResource articleTranslationResource;
        private OrderHistoryResource orderHistoryResource;

        public ShopwareApi(string url, string username, string password)
        {
            Debug.WriteLine("Shopware API for URL \"" + url + "\" started");
            Debug.WriteLine("Username: " + username);
            Debug.WriteLine("API Key: " + password);

            this.url = url;
            this.username = username;
            this.password = password;

            this.client = new RestClient(url);
            client.Authenticator = new DigestAuthenticator(username, password);
        }

        public ArticleRessource getArticleRessource()
        {
            if (this.articleRessource == null)
            {
                this.articleRessource = new ArticleRessource(this.client);
            }
            return this.articleRessource;
        }

        public CategoryRessource getCategoryRessource()
        {
            if (this.categoryRessource == null)
            {
                this.categoryRessource = new CategoryRessource(this.client);
            }
            return this.categoryRessource;
        }

        public OrderResource getOrderResource()
        {
            if (this.orderResource == null)
            {
                this.orderResource = new OrderResource(this.client);
            }
            return this.orderResource;
        }

        public ManufacturerResource getManufacturerResource()
        {
            if (this.manufacturerResource == null)
            {
                this.manufacturerResource = new ManufacturerResource(this.client);
            }
            return this.manufacturerResource;
        }

        public MediaResource getMediaResource()
        {
            if (this.mediaResource == null)
            {
                this.mediaResource = new MediaResource(this.client);
            }
            return this.mediaResource;
        }

        public CustomerResource getCustomerResource()
        {
            if (this.customerResource == null)
            {
                this.customerResource = new CustomerResource(this.client);
            }
            return this.customerResource;
        }

        public ArticleTranslationResource getArticleTranslationResource()
        {
            if (this.articleTranslationResource == null)
            {
                this.articleTranslationResource = new ArticleTranslationResource(this.client);
            }
            return this.articleTranslationResource;
        }

        public OrderHistoryResource getOrderHistoryResource()
        {
            if (this.orderHistoryResource == null)
            {
                this.orderHistoryResource = new OrderHistoryResource(this.client);
            }
            return this.orderHistoryResource;
        }
    }

    public class DigestAuthenticator : IAuthenticator
    {
        private readonly string _user;
        private readonly string _pass;

        public DigestAuthenticator(string user, string pass)
        {
            _user = user;
            _pass = pass;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.Credentials = new NetworkCredential(_user, _pass);
        }
    }
}
