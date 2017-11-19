using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Util
{
    public class BeagleConfig
    {
        private IConfiguration _configuration;
        private IDictionary _envVariables;
        private bool _isLinux;

        public BeagleConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            _envVariables = Environment.GetEnvironmentVariables();
            _isLinux = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux);
        }

        private string GetEnv(string key)
        {
            if (_isLinux)
            {
                return _configuration[key].ToString();
            }

            return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);
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
                return GetEnv(_configuration["ExternalServices:Images:ApiKeyEnvironmentVariable"]);
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
                return GetEnv(_configuration["ExternalServices:Google:ApiKeyEnvironmentVariable"]);
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
                return GetEnv(_configuration["ExternalServices:Weather:ApiKeyEnvironmentVariable"]);
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
                return GetEnv(_configuration["ExternalServices:Reddit:ClientIdEnvironmentVariable"]);
            }
        }

        public string ExtRedditClientSecret
        {
            get
            {
                return GetEnv(_configuration["ExternalServices:Reddit:ClientSecretEnvironmentVariable"]);
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
