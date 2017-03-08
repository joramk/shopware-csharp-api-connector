using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Lenz.ShopwareApi
{

    /// <summary>
    /// FilterData class holds properties of each filter to be applied to the api request
    /// </summary>
    public class FilterData
    {
        private string fd_property;         // required
        private string fd_expression;       // default is "LIKE"
        private string fd_value;            // required
        private int? fd_operator;

        public FilterData(string property, string value)
        {
            fd_property = property;
            fd_value = value;
        }

        public FilterData(string property, string value, string expression)
        {
            fd_property = property;
            fd_value = value;
            fd_expression = expression;
        }

        public FilterData(string property, string value, string expression, int? i_operator)
        {
            fd_property = property;
            fd_value = value;
            fd_expression = expression;
            fd_operator = i_operator;
        }

        public Dictionary<string, string> GetData()
        {
            if (string.IsNullOrEmpty(fd_property) || string.IsNullOrEmpty(fd_value))
            {
                throw new Exception("FilterData must contain property and value");
            }
            Dictionary<string, string> l_result = new Dictionary<string, string>();
            l_result.Add("property", fd_property);
            if (!string.IsNullOrEmpty(fd_expression))
            {
                l_result.Add("expression", fd_expression);
            }
            l_result.Add("value", fd_value);
            if (fd_operator != null)
            {
                l_result.Add("operator", fd_operator.ToString());
            }
            return l_result;
        }
    }

    /// <summary>
    /// SortData class contains the properties of a single sort to be applied to the api request
    /// </summary>
    public class SortData
    {
        private string sd_property;
        private string sd_direction;

        public void SetProperty(string s)
        {
            sd_property = s;
        }

        public void SetDirection(string s)
        {
            sd_direction = s;
        }

        public Dictionary<string, string> GetData()
        {
            if (string.IsNullOrEmpty(sd_property))
            {
                throw new Exception("SortData must contain property");
            }
            Dictionary<string, string> l_result = new Dictionary<string, string>();
            l_result.Add("property", sd_property);
            if (!string.IsNullOrEmpty(sd_direction))
            {
                l_result.Add("direction", sd_direction);
            }
            return l_result;
        }
    }

    /// <summary>
    /// ParamData class describes the data that can be passed as parameters: a filter, a sorting and limitation infomration
    /// </summary>
    public class ParamData
    {
        private List<FilterData> filters = new List<FilterData>();   
        private List<SortData> sorting = new List<SortData>();
        private Dictionary<string, int> pd_dict_int = new Dictionary<string, int>();

        public int GetFilterCount()
        {
            return filters.Count;
        }

        public int GetSortingCount()
        {
            return sorting.Count;
        }

        /// <summary>
        /// Add parameters to the request
        /// </summary>
        public void AddToRequest(RestRequest rr)
        {
            int i = 0;      // index of our list
            foreach(var filter in filters)
            {
                var dict = filter.GetData();
                foreach(var d in dict)
                {
                    rr.AddQueryParameter("filter[" + i.ToString() + "][" + d.Key + "]", d.Value);
                }
            }
            foreach(var sort in sorting)
            {
                var dict = sort.GetData();
                foreach (var d in dict)
                {
                    rr.AddQueryParameter("sort[" + i.ToString() + "][" + d.Key + "]", d.Value);
                }
            }
            foreach(var entry in pd_dict_int)
            {
                rr.AddQueryParameter(entry.Key, entry.Value.ToString());
            }
        }

        public Dictionary<string,string> GetFilter(int index)
        {
            return filters[index].GetData();
        }

        public Dictionary<string, string> GetSorting(int index)
        {
            return sorting[index].GetData();
        }

        public string GetParam(string param)
        {
            if (pd_dict_int.ContainsKey(param))
            {
                return pd_dict_int[param].ToString();
            }
            return null;
        }

        public void AddParameter(string key, int value)
        {
            pd_dict_int[key] = value;
        }

        public void SetLimit(int limit)
        {
            pd_dict_int["limit"] = limit;
        }

        public void SetStart(int start)
        {
            pd_dict_int["start"]= start;
        }

        public void AddFilter(FilterData fd)
        {
            filters.Add(fd);
        }

        public void AddSorting(SortData sd)
        {
            sorting.Add(sd);
        }
    }

    public class ApiRequest
    {
        private string url;
        private RestSharp.Method method;

        private ParamData parameters = new ParamData();
        private string body;

        public string Url
        {
            get
            {
                return url;
            }
        }

        public Method Method
        {
            get
            {
                return method;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }
        }

        public ApiRequest(String url, RestSharp.Method method)
        {
            this.url = url;
            this.method = method;
        }

        public void AddFilter(FilterData fd)
        {
            parameters.AddFilter(fd);
        }

        public void AddSorting(SortData sd)
        {
            parameters.AddSorting(sd);
        }

        public void AddLimit(int limit)
        {
            parameters.SetLimit(limit);
        }

        public void AddStart(int start)
        {
            parameters.SetStart(start);
        }

        public void setBody(string body)
        {
            this.body = body;
        }
    }
}
