using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models.External;
using TravellingBeagle.Models.External.Google.GeoCode;
using TravellingBeagle.Models.External.OpenWeatherMap;
using TravellingBeagle.Models.External.Reddit;

namespace TravellingBeagle.Services
{
    public interface IRestService
    {
        Task<List<CountryDetailsModel>> GetCountries();
        Task<CountryDetailsModel> GetCountryDetails(string countryIso);

        Task<List<string>> GetImageUrls(string q);

        Task<Coordinates> GetCoordinates(CountryDetailsModel details);
        Task<double> GetUtcOffsetAtCoordinates(double longitude, double latitude);

        Task<WeatherResponse> GetWeatherAtCoordinates(double longitude, double latitude);

        Task<AuthorizationResponse> AuthorizeReddit();
        Task<RedditSearchResponse> SearchReddit(string q, AuthorizationResponse authorization);
    }
}
