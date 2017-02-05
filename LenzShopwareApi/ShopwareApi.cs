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
        private OrderRessource orderRessource;
        private ManufacturerResource manufacturerResource;
        private MediaResource mediaResource;

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

        public ICategoryRessource getCategoryRessource()
        {
            if (this.categoryRessource == null)
            {
                this.categoryRessource = new CategoryRessource(this.client);
            }
            return this.categoryRessource;
        }

        public OrderRessource getOrderRessource()
        {
            if (this.orderRessource == null)
            {
                this.orderRessource = new OrderRessource(this.client);
            }
            return this.orderRessource;
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
