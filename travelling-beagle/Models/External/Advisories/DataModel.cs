using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellingBeagle.Models.External.Advisories
{
    public class DataModel
    {
        [JsonProperty(PropertyName = "lang")]
        public LangModel Lang { get; set; }

        [JsonProperty(PropertyName = "situation")]
        public SituationModel Situation { get; set; }
    }
}
