using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Reddit
{
    public class ChildModel
    {
        [JsonProperty(PropertyName = "data")]
        public ChildDataModel Data;
    }
}
