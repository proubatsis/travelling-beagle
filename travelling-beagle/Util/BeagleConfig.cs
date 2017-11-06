using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Util
{
    public class BeagleConfig
    {
        private IConfiguration _configuration;

        public BeagleConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ExtCountryServiceUrl
        {
            get
            {
                return _configuration["ExternalServices:Countries:Url"];
            }
        }

        public string ExtImagesUrl
        {
            get
            {
                return _configuration["ExternalServices:Images:Url"];
            }
        }

        public string ExtImagesApiKey
        {
            get
            {
                return Environment.GetEnvironmentVariable(
                    _configuration["ExternalServices:Images:ApiKeyEnvironmentVariable"],
                    EnvironmentVariableTarget.User);
            }
        }

        public string ExtGoogleGeoCodeUrl
        {
            get
            {
                return _configuration["ExternalServices:Google:GeoCodeUrl"];
            }
        }

        public string ExtGoogleTimezoneUrl
        {
            get
            {
                return _configuration["ExternalServices:Google:TimezoneUrl"];
            }
        }

        public string ExtGoogleApiKey
        {
            get
            {
                return Environment.GetEnvironmentVariable(
                    _configuration["ExternalServices:Google:ApiKeyEnvironmentVariable"],
                    EnvironmentVariableTarget.User);
            }
        }

        public string ExtWeatherUrl
        {
            get
            {
                return _configuration["ExternalServices:Weather:Url"];
            }
        }

        public string ExtWeatherApiKey
        {
            get
            {
                return Environment.GetEnvironmentVariable(
                    _configuration["ExternalServices:Weather:ApiKeyEnvironmentVariable"],
                    EnvironmentVariableTarget.User);
            }
        }

        public string ExtRedditAuthorizeUrl
        {
            get
            {
                return _configuration["ExternalServices:Reddit:AuthorizeUrl"];
            }
        }

        public string ExtRedditUrl
        {
            get
            {
                return _configuration["ExternalServices:Reddit:Url"];
            }
        }

        public string ExtRedditClientId
        {
            get
            {
                return Environment.GetEnvironmentVariable(
                    _configuration["ExternalServices:Reddit:ClientIdEnvironmentVariable"],
                    EnvironmentVariableTarget.User);
            }
        }

        public string ExtRedditClientSecret
        {
            get
            {
                return Environment.GetEnvironmentVariable(
                    _configuration["ExternalServices:Reddit:ClientSecretEnvironmentVariable"],
                    EnvironmentVariableTarget.User);
            }
        }

        public string ExtAdvisoryUrl
        {
            get
            {
                return _configuration["ExternalServices:TravelAdvisories:Url"];
            }
        }
    }
}
