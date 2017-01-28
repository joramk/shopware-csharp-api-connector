using Lenz.ShopwareApi.Models.Suppliers;
using System;
using RestSharp;

namespace Lenz.ShopwareApi.Ressources
{
    public class ManufacturerResource : SuperRessource<Supplier>, IManufacturerResource
    {
        public ManufacturerResource(IRestClient client) : base(client)
        {
            ressourceUrl = "manufacturers";
        }

        public new int add(Supplier manufacturer)
        {
            if (manufacturer.name != null)
            {
                ApiPostResponse response = base.add(manufacturer);
                return response.id.GetValueOrDefault();
            }
            throw new Exception("Minimum required field for manufacturer add: supplier.name");
        }

        public new void update(Supplier manufacturer)
        {
            if (manufacturer.name != null && manufacturer.id != null)
            {
                base.executeUpdate(manufacturer, manufacturer.id.ToString());
                return;
            }
            throw new Exception("Minim required field for manufacturer update: supplier.name, supplier.id");
        }

    }
}
