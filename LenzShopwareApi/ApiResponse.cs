using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi
{
    // simple API response (e.g. on simple deletes or updates)
    public class ApiSimpleResponse
    {
        public bool success;            // indicates success or failure
        public string message;          // only on failure
        public List<string> errors;     // details about the error (e.g. Validation error details)
    }

    // API response with data (e.g. on adding, or subresponse of a batch method call)
    public class ApiResponse<TData> : ApiSimpleResponse
    {
        public string operation;        // only on batch responses, type of action executed ("delete", "create" or "update")
        public TData data;              // the object of the operation
    }

    // Response of a batch method
    // "data" object is array of responses
    public class ApiBatchResponse<TData> : ApiSimpleResponse
    {
        public List<ApiResponse<TData>> data;
    }

    // Responsedata of POST method  (= add operation)
    //   "data" object will contain "id" and "location" of the newly created object
    public class ApiPostResponseData
    {
        public int? id;
        public string location;
    }
}
