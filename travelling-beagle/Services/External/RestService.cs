using Microsoft.Extensions.Logging;
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

namespace TravellingBeagle.Services.External
{
    public class RestService : IRestService
    {
        private BeagleConfig _config;
        private ILogger<RestService> _logger;

        public RestService(BeagleConfig config, ILogger<RestService> logger)
        {
            _config = config;
            _logger = logger;
        }

        private async Task<T> Get<T>(string url)
        {
            _logger.LogDebug("GET Request: {0}", url);

            var request = WebRequest.Create(url);
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
                _config.ExtGoogleApiKey));

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
                _config.ExtWeatherApiKey));
        }
    }
}
