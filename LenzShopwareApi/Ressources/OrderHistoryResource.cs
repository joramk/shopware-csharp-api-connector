using Lenz.ShopwareApi.Models.Orders;
using RestSharp;
using System;

namespace Lenz.ShopwareApi.Ressources
{
    public class OrderHistoryResource : SuperRessource<OrderHistory>
    {
        public OrderHistoryResource(IRestClient client)
            : base(client)
        {
            ressourceUrl = "memaxhistory";
        }

        public new int add(OrderHistory oh)
        {
            if ((oh.customerId != null) || (oh.customer != null) )
            {
                ApiPostResponseData response = base.add(oh);
                return response.id.GetValueOrDefault();
            }
            throw new Exception("Customer data (id or array) is missing to add the new orderhistory via Shopware REST API.");
        }

        public void delete()
        {
            throw new NotImplementedException("Delete orderhistory not yet implemented.");
        }

        public new void update(OrderHistory oh)
        {
            if (oh.id != null)
            {
                base.executeUpdate(oh, oh.id.ToString());
                return;
            }
            throw new Exception("Minimum required fields for orderhistory update: orderhistory.id");
        }
    }
}
