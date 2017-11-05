using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Util
{
    public class BeagleConfig
    {
        private string extCountryServiceUrl;

        public BeagleConfig(IConfiguration configuration)
        {
            this.extCountryServiceUrl = configuration["ExternalServices:Countries:Url"];
        }

        public string ExtCountryServiceUrl
        {
            get
            {
                return extCountryServiceUrl;
            }
        }
    }
}
