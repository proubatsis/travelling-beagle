using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellingBeagle.Models.External.Advisories
{
    public class SituationModel
    {
        [JsonProperty(PropertyName = "rating")]
        public string Rating { get; set; }
    }
}
