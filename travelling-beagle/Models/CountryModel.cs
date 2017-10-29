using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Models
{
    public class CountryModel
    {
        public string Stub { get; set; }
        public string Name { get; set; }
        public List<string> Images { get; set; }
    }
}
