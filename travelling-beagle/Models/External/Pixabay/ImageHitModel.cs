using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models.External.Pixabay
{
    public class ImageHitModel
    {
        [JsonProperty(PropertyName = "webformatURL")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "imageWidth")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "imageHeight")]
        public int Height { get; set; }
    }
}
