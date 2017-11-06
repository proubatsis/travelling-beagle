using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Advisories
{
    public class AdvisoryResponse
    {
        [JsonProperty(PropertyName = "api_status")]
        public ApiStatusModel ApiStatus { get; set; }

        [JsonProperty(PropertyName = "data")]
        public DataModel Data { get; set; }
    }
}
