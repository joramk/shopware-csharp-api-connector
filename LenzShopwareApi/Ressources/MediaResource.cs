using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Lenz.ShopwareApi.Models.Images;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Ressources
{
    public class MediaResource : SuperRessource<Media>, IMediaResource
    {
        public MediaResource(IRestClient client) : base (client)
        {
            ressourceUrl = "media";
        }

        //public new List<Media> getAll()
        //{
        //    ApiRequest request = new ApiRequest(this.ressourceUrl, Method.GET);
        //    ApiRequestExecutor executor = new ApiRequestExecutor();

        //    ApiResponse<List<Media>> response = executor.execute<List<Media>>(client, request);

        //    return response.data;
        //}

        public new ApiPostResponseData add(Media media)
        {
            if ( (media.album !=0) && (media.file != null))
            {
                String json = JsonConvert.SerializeObject(media, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                ApiResponse < ApiPostResponseData > response = convertResponseStringToObject<ApiPostResponseData>(execute(this.ressourceUrl, Method.POST, null, null, json));
                if (!response.success)
                {
                    throw new Exception(response.message);
                }
                return response.data;
            }
            throw new Exception("Minimum required fields for media add: 'album' and 'file'");
        }

        public void delete(int id)
        {
            base.delete(id.ToString());
        }
    }
}
