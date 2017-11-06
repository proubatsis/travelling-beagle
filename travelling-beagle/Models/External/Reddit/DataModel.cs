using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Reddit
{
    public class DataModel
    {
        [JsonProperty(PropertyName = "children")]
        public List<ChildModel> Children { get; set; }
    }
}
