using System;
using System.Collections.Generic;
using Lenz.ShopwareApi.Models.Images;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Ressources
{
    public interface IMediaResource
    {
//        List<Media> getAll();

        Media get(int id);

        ApiPostResponseData add(Media media);

        void delete(int id);
    }
}
