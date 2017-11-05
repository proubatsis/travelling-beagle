using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.OpenWeatherMap
{
    public class MainModel
    {
        [JsonProperty(PropertyName = "temp")]
        public double TemperatureInKelvin { get; set; }
    }
}
