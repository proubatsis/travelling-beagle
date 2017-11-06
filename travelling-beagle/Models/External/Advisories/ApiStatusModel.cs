using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellingBeagle.Models.External.Advisories
{
    public class ApiStatusModel
    {
        [JsonProperty(PropertyName = "reply")]
        public ReplyModel Reply { get; set; }
    }
}
