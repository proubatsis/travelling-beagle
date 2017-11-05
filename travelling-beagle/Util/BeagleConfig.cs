﻿using Microsoft.Extensions.Configuration;
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
    }
}
