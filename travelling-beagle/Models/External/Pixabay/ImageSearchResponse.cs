using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Pixabay
{
    public class ImageSearchResponse
    {
        [JsonProperty(PropertyName = "totalHits")]
        public int TotalHits { get; set; }

        [JsonProperty(PropertyName = "hits")]
        public List<ImageHitModel> Hits;
    }
}
