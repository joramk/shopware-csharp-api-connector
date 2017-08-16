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

        public new int add(Customer c)
        {
            ApiPostResponseData response = base.add(c);
            return response.id.GetValueOrDefault();
        }
    }
}
