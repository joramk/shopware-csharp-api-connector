using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi
{
    public class ApiResponse<TData>
    {
        public TData data;
        public Boolean success;
        public string message;
        public List<string> errors;     // details about the error (e.g. Validation error details)
    }

    public class ApiPostResponse
    {
        public int? id;
        public string location;
    }
}
