using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Google.GeoCode
{
    public class GeometryModel
    {
        [JsonProperty(PropertyName = "location")]
        public Coordinates Location { get; set; }
    }
}
