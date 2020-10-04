﻿using Newtonsoft.Json.Linq;

namespace MyBank.WebApp.Api.Queries
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
