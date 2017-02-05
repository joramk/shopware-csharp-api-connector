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

        private class MediaUpload : Media
        {
            protected string file;
            public MediaUpload(Media m, string f) : base(m.id, m.albumId, m.name, m.description, m.path, m.type, m.extension, m.userId, m.created, m.fileSize)
            {
                file = f;
            }
        }

        public new List<Media> getAll()
        {
            ApiRequest request = new ApiRequest(this.ressourceUrl, Method.GET);
            ApiRequestExecutor executor = new ApiRequestExecutor();

            ApiResponse<List<Media>> response = executor.execute<List<Media>>(client, request);

            return response.data;
        }

        public ApiPostResponse add(Media media, string file)
        {
            if ( (media.albumId !=0) && (file != null))
            {
                MediaUpload mu = new MediaUpload(media, file);
                String json = JsonConvert.SerializeObject(mu, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                ApiResponse < ApiPostResponse > response = convertResponseStringToObject<ApiPostResponse>(execute(this.ressourceUrl, Method.POST, null, json));
                if (!response.success)
                {
                    throw new Exception(response.message);
                }
                return response.data;
            }
            throw new Exception("Minimum required fields for media add: media.albumID and file to upload");
        }

        public void delete(int id)
        {
            base.delete(id.ToString());
        }
    }
}
