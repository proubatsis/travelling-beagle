using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Google.Timezone
{
    public class TimezoneResponse
    {
        [JsonProperty(PropertyName = "rawOffset")]
        public double RawOffset { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
