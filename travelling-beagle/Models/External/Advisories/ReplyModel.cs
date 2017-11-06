using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravellingBeagle.Models.External.Advisories
{
    public class ReplyModel
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
    }
}
