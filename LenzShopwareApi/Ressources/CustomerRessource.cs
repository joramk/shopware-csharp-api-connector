using Lenz.ShopwareApi.Models.Customers;
using RestSharp;
using System;

namespace Lenz.ShopwareApi.Ressources
{
    public class CustomerResource : SuperRessource<Customer>, ICustomerResource
    {
        public CustomerResource(IRestClient client)
            : base (client)
        {
            ressourceUrl = "customers";
        }
    }
}
