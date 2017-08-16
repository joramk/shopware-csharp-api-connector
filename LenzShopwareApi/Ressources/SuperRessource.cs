using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Lenz.ShopwareApi.Ressources
{
    public abstract class SuperRessource<TResponse>
    {
        protected string ressourceUrl;

        protected IRestClient client { get; set; }

        public SuperRessource(IRestClient client) {
            this.client = client;
        }

        public TResponse get(int id)
        {
            try
            {
                return this.get(id.ToString());
            }
            catch (Exception e)
            {
                // Pass exception to next level.
                throw e;
            }
        }

        public TResponse get(string id, bool useNumberAsId = false)
        {
            ApiResponse<TResponse> response = convertResponseStringToObject<TResponse>(this.executeGet(id, useNumberAsId));
            if (!response.success)
            {
                throw new Exception(response.message);
            }
            return response.data;
        }

        public List<TResponse> getAll(ParamData parameters)
        {
            ApiResponse<List<TResponse>> response = convertResponseStringToObject<List<TResponse>>(execute(this.ressourceUrl+"/", Method.GET, null, parameters, null));
            if(!response.success)
            {
                throw new Exception(response.message);
            }
            return response.data;
        }

        public ApiPostResponseData add(TResponse data)
        {
            ApiResponse<ApiPostResponseData> response = convertResponseStringToObject<ApiPostResponseData>(this.executeAdd(data));
            if (!response.success)
            {
                throw new Exception(response.message);
            }
            return response.data;
        }

        protected string executeAdd(TResponse data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Debug.WriteLine(json);
            return this.execute(this.ressourceUrl, Method.POST, null, null, json);
        }

        public void update(TResponse data)
        {
            string response = this.executeUpdate(data, "");
        }

        protected string executeUpdate(TResponse data, string id)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Debug.WriteLine(json);

            // set id.
            List<KeyValuePair<string, string>> urlData = new List<KeyValuePair<string, string>>();
            urlData.Add(new KeyValuePair<string, string>("id", id));
            return this.execute(this.ressourceUrl + "/{id}", Method.PUT, urlData, null, json);
        }

        public bool delete(string id)
        {
            ApiSimpleResponse response = convertResponseStringToObject(this.executeDelete(id));
            if (!response.success)
            {
                throw new Exception(response.message);
            }
            return true;
        }

        public List<ApiResponse<TResponse>> delete(int[] arr_ids)
        {
            ApiBatchResponse<TResponse> response = convertBatchResponseStringToObject<TResponse>(this.executeDelete(arr_ids));
            if (!response.success)
            {
                throw new Exception(response.message);
            }
            return response.data;
        }

        protected string executeDelete(string id)
        {
            // set id.
            List<KeyValuePair<string, string>> urlData = new List<KeyValuePair<string, string>>();
            urlData.Add(new KeyValuePair<string, string>("id", id));
            string response = this.execute(this.ressourceUrl + "/{id}", Method.DELETE, urlData);
            return response;
        }

        protected string executeDelete(int[] arr_ids)
        {
            // convert the array of ids to delete into array( 'id' => id ) style
            List<Tuple<string, int>> data = new List<Tuple<string, int>>();
            foreach(int i in arr_ids)
            {
                data.Add(new Tuple<string, int> ( "id", i ));
            }

            // now get this list in json format to add it to the body of the request
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return execute(ressourceUrl, Method.DELETE, null, null, json);
        }

        protected ApiSimpleResponse convertResponseStringToObject(string responsestring)
        {
            return JsonConvert.DeserializeObject<ApiSimpleResponse>(responsestring, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        protected ApiResponse<A> convertResponseStringToObject<A>(string responsestring)
        {
            return JsonConvert.DeserializeObject<ApiResponse<A>>(responsestring, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        protected ApiBatchResponse<A> convertBatchResponseStringToObject<A>(string responsestring)
        {
            return JsonConvert.DeserializeObject<ApiBatchResponse<A>>(responsestring, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        protected string executeGet(string id, bool useNumberAsId = false)
        {
            // set id.
            List<KeyValuePair<string, string>> urlData = new List<KeyValuePair<string, string>>();
            urlData.Add(new KeyValuePair<string, string>("id", id));
            string sUrl = this.ressourceUrl + "/{id}";
            if (useNumberAsId)
            {
                sUrl += "?useNumberAsId=true";
            }
            string response = this.execute(sUrl, Method.GET, urlData);
            return response;
        }

        private string execute(string ressource, RestSharp.Method method, List<KeyValuePair<string, string>> urlData)
        {
            return execute(ressource, method, urlData, null, "");
        }

        private string execute(ApiRequest request)
        {
            return "";
        }

        protected string execute(string ressource, RestSharp.Method method, List<KeyValuePair<string, string>> urlData, ParamData parameters, string body)
        {
            var request = new RestRequest(ressource, method);
            request.RequestFormat = DataFormat.Json;

            if (urlData != null)
            {
                foreach (KeyValuePair<string, string> parameter in urlData)
                {
                    request.AddUrlSegment(parameter.Key, parameter.Value);          // replaces matching token in request.Resource
                }
            }

            // add queryparameters if present
            if (parameters != null)
            {
                parameters.AddToRequest(request);
            }

            // send body if it is available
            if (!string.IsNullOrEmpty(body))
            {
                request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            }

            // execute the request
            IRestResponse response = client.Execute(request);

            if (response.ErrorException != null)
            {
                Debug.WriteLine("Api Error:");
                Debug.WriteLine(response.ErrorException.Message);
            }
            else
            {
                string content = response.Content; // raw content as string
                Debug.WriteLine(content);
                return content;
            }
            return "failed";
        }
    }
}
