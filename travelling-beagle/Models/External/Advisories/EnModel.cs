using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellingBeagle.Models.External.Advisories
{
    public class EnModel
    {
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "continent")]
        public string Continent { get; set; }

        [JsonProperty(PropertyName = "url_details")]
        public string UrlDetails { get; set; }

        [JsonProperty(PropertyName = "advice")]
        public string Advice { get; set; }
    }
}
