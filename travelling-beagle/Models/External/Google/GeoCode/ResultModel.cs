using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Google.GeoCode
{
    public class ResultModel
    {
        [JsonProperty(PropertyName = "geometry")]
        public GeometryModel Geometry { get; set; }
    }
}
