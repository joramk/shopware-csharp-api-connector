using Lenz.ShopwareApi.Models.Orders;
using RestSharp;
using System;

namespace Lenz.ShopwareApi.Ressources
{
    public class MerchantOrderRessource : SuperRessource<MerchantOrder>, IMerchantOrderRessource
    {
        public MerchantOrderRessource(IRestClient client)
            : base (client)
        {
            ressourceUrl = "MerchantOrders";
        }

        public void add()
        {
            throw new NotImplementedException("It is not allowed to add merchant orders via Shopware REST API.");
        }

        public void delete()
        {
            throw new NotImplementedException("It is not allowed to delete merchant orders via Shopware REST API.");
        }
    }
}
