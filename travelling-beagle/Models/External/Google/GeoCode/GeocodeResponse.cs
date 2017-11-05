using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Google.GeoCode
{
    public class GeoCodeResponse
    {
        [JsonProperty(PropertyName = "results")]
        public List<ResultModel> Results { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
