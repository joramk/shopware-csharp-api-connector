using Lenz.ShopwareApi.Models.Suppliers;
using System.Collections.Generic;

namespace Lenz.ShopwareApi.Ressources
{
    public interface IManufacturerResource
    {
//        List<Supplier> getAll();    // getAll will retrieve complete list, but no attributes (as currently in 5.2.16)

        Supplier get(int id);       // get will retrieve all data, included any defined free fields in the backend (as "attribute")

        int add(Supplier manufacturer);

        void update(Supplier manufacturer);

    }
}
