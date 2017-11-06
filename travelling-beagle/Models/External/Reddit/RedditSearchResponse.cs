using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Reddit
{
    public class RedditSearchResponse
    {
        [JsonProperty(PropertyName = "data")]
        public DataModel Data { get; set; }
    }
}
