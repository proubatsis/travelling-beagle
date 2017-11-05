using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models.Country;

namespace TravellingBeagle.Models
{
    public class CountryModel
    {
        public string IsoCode { get; set; } // ISO ALPHA-3 Code
        public string Stub { get; set; }
        public string Name { get; set; }

        public CityModel CapitalCity { get; set; }

        public List<string> Images { get; set; }
        public List<ExternalLink> RedditLinks { get; set; }
        public List<ExternalLink> TravelBlogLinks { get; set; }
    }
}
