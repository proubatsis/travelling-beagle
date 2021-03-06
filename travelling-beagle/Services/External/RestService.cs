﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using TravellingBeagle.Models.External;
using TravellingBeagle.Models.External.Pixabay;
using TravellingBeagle.Util;
using TravellingBeagle.Models.External.Google.GeoCode;
using TravellingBeagle.Models.External.Google.Timezone;
using TravellingBeagle.Extensions;
using TravellingBeagle.Models.External.OpenWeatherMap;
using TravellingBeagle.Models.External.Reddit;
using System.Text;
using TravellingBeagle.Models.External.Advisories;
using TravellingBeagle.Caching;

namespace TravellingBeagle.Services.External
{
    public class RestService : IRestService
    {
        private const double CACHE_TTL_STANDARD = 259200.0;
        private const double CACHE_TTL_SHORT = 3600.0;

        private BeagleConfig _config;
        private ILogger<RestService> _logger;
        private IBeagleCache _cache;

        public RestService(BeagleConfig config, ILogger<RestService> logger, IBeagleCache cache)
        {
            _config = config;
            _logger = logger;
            _cache = cache;
        }

        private Task<T> Get<T>(string url, bool useCache = true, double ttlSeconds = CACHE_TTL_STANDARD)
        {
            return GetWithHeaders<T>(url, new Dictionary<string, string>(), useCache, ttlSeconds);
        }

        private async Task<T> GetWithHeaders<T>(string url, Dictionary<string, string> headers, bool useCache = true, double ttlSeconds = CACHE_TTL_STANDARD)
        {
            var cacheKey = url + "|" + String.Join("|", from h in headers.ToList() select String.Format("{0}: {1}", h.Key, h.Value));

            if(useCache)
            {
                var cached = await _cache.GetFromCache(cacheKey);

                if (cached != null)
                {
                    return JsonConvert.DeserializeObject<T>(cached);
                }
            }

            _logger.LogInformation("GET Request: {0}", url);
            var request = WebRequest.Create(url);

            foreach (var header in headers.ToList())
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = await request.GetResponseAsync();
            var reader = new StreamReader(response.GetResponseStream());
            var responseBody = await reader.ReadToEndAsync();
            reader.Close();

            if(useCache) await _cache.Cache(cacheKey, responseBody, ttlSeconds);
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        private async Task<T> PostWithBasicAuth<T>(string url, string username, string password)
        {
            _logger.LogInformation("POST/BASIC-AUTH: {0} - {1}:{2}", url, username, password);

            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add(
                "Authorization",
                String.Format("Basic {0}", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password))));

            var response = await request.GetResponseAsync();
            var reader = new StreamReader(response.GetResponseStream());
            var responseBody = await reader.ReadToEndAsync();
            reader.Close();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public Task<List<CountryDetailsModel>> GetCountries()
        {
            return Get<List<CountryDetailsModel>>(String.Format(
                "{0}/all",
                _config.ExtCountryServiceUrl
                ));
        }

        public Task<CountryDetailsModel> GetCountryDetails(string countryIso)
        {
            return Get<CountryDetailsModel>(String.Format(
                "{0}/alpha/{1}",
                _config.ExtCountryServiceUrl,
                countryIso));
        }

        public async Task<List<string>> GetImageUrls(string q)
        {
            var searchResponse = await Get<ImageSearchResponse>(String.Format(
                "{0}?q={1}&key={2}&image_type=photo",
                _config.ExtImagesUrl,
                HttpUtility.UrlEncode(q),
                _config.ExtImagesApiKey
                ));
            var urls = from hit in searchResponse.Hits select hit.Url;
            return urls.ToList();
        }

        public async Task<Coordinates> GetCoordinates(CountryDetailsModel details)
        {
            var response = await Get<GeoCodeResponse>(String.Format(
                "{0}?address={1},{2}&key={3}",
                _config.ExtGoogleGeoCodeUrl,
                HttpUtility.UrlEncode(details.CapitalCity),
                HttpUtility.UrlEncode(details.Name),
                _config.ExtGoogleApiKey));
            
            if (response.Status.Equals("OK") && response.Results != null && response.Results.Count > 0)
            {
                return response.Results[0].Geometry.Location;
            }

            return null;
        }

        public async Task<double> GetUtcOffsetAtCoordinates(double longitude, double latitude)
        {
            var response = await Get<TimezoneResponse>(String.Format(
                "{0}?location={1},{2}&timestamp={3}&key={4}",
                _config.ExtGoogleTimezoneUrl,
                latitude,
                longitude,
                DateTime.UtcNow.GetEpochTime(),
                _config.ExtGoogleApiKey), false);

            if (response.Status.Equals("OK"))
            {
                return response.RawOffset;
            }

            return 0.0;
        }

        public Task<WeatherResponse> GetWeatherAtCoordinates(double longitude, double latitude)
        {
            return Get<WeatherResponse>(String.Format(
                "{0}?lat={1}&lon={2}&appid={3}",
                _config.ExtWeatherUrl,
                latitude,
                longitude,
                _config.ExtWeatherApiKey), true, CACHE_TTL_SHORT);
        }

        public Task<AuthorizationResponse> AuthorizeReddit()
        {
            return PostWithBasicAuth<AuthorizationResponse>(
                _config.ExtRedditAuthorizeUrl,
                _config.ExtRedditClientId,
                _config.ExtRedditClientSecret);
        }

        public Task<RedditSearchResponse> SearchReddit(string q, AuthorizationResponse authorization)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", String.Format("{0} {1}", authorization.TokenType, authorization.AccessToken));
            headers.Add("User-Agent", "TravellingBeagle");

            return GetWithHeaders<RedditSearchResponse>(
                String.Format("{0}/search?q={1}", _config.ExtRedditUrl, HttpUtility.UrlEncode(q)),
                headers);
        }

        public Task<AdvisoryResponse> GetTravelAdvisory(CountryDetailsModel details)
        {
            return Get<AdvisoryResponse>(String.Format("{0}?country={1}", _config.ExtAdvisoryUrl, details.Iso2));
        }
    }
}
