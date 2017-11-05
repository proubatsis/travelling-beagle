using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.OpenWeatherMap
{
    public class WeatherResponse
    {
        [JsonProperty(PropertyName = "main")]
        public MainModel Main { get; set; }
    }
}
