using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External
{
    public class CountryDetailsModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "alpha3Code")]
        public string Iso3 { get; set; }

        [JsonProperty(PropertyName = "alpha2Code")]
        public string Iso2 { get; set; }

        [JsonProperty(PropertyName = "capital")]
        public string CapitalCity { get; set; }

        [JsonProperty(PropertyName = "flag")]
        public string FlagImage { get; set; }
    }
}
