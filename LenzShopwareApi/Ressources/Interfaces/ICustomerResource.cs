using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lenz.ShopwareApi.Models.Customers;

namespace Lenz.ShopwareApi.Ressources
{
    public interface ICustomerResource
    {
        List<Customer> getAll();

        Customer get(int id);

        Customer get(string id);

        ApiPostResponse add(Customer c);

        void update(Customer c);
    }
}
