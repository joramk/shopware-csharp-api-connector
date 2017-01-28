﻿using Newtonsoft.Json;
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
    }

    public class ApiPostResponse
    {
        public int? id;
        public string location;
    }
}
