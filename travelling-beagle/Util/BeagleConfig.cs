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
        private string extImagesUrl;
        private string extImagesApiKey;

        public BeagleConfig(IConfiguration configuration)
        {
            this.extCountryServiceUrl = configuration["ExternalServices:Countries:Url"];

            this.extImagesUrl = configuration["ExternalServices:Images:Url"];
            this.extImagesApiKey = Environment.GetEnvironmentVariable(
                configuration["ExternalServices:Images:ApiKeyEnvironmentVariable"],
                EnvironmentVariableTarget.User);
        }

        public string ExtCountryServiceUrl
        {
            get
            {
                return extCountryServiceUrl;
            }
        }

        public string ExtImagesUrl
        {
            get
            {
                return extImagesUrl;
            }
        }

        public string ExtImagesApiKey
        {
            get
            {
                return extImagesApiKey;
            }
        }
    }
}
