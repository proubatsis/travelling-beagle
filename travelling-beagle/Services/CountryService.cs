using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models;
using TravellingBeagle.Models.Country;
using TravellingBeagle.Models.External;
using TravellingBeagle.Models.External.Advisories;
using TravellingBeagle.Models.External.Reddit;
using TravellingBeagle.Util;

namespace TravellingBeagle.Services
{
    public class CountryService : ICountryService
    {
        private const int MAX_IMAGES = 9;
        private const string REDDIT_BASE_URL = "https://reddit.com";

        private IRestService _restService;

        // Reddit API
        private static DateTime _refreshRedditTime = DateTime.UtcNow;
        private static AuthorizationResponse _redditAuthorization = null;


        public CountryService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<CountryModel> FindCountryByStub(string countryStub)
        {
            var details = await _restService.GetCountryDetails(countryStub);
            var images = await _restService.GetImageUrls(details.Name);

            var coord = await _restService.GetCoordinates(details);
            var utcOffset = await _restService.GetUtcOffsetAtCoordinates(coord.Longitude, coord.Latitude);

            var weatherResponse = await _restService.GetWeatherAtCoordinates(coord.Longitude, coord.Latitude);

            var redditPosts = await GetRedditPosts(details);
            var redditInternalPosts = from post in redditPosts where post.Url.Contains("reddit.com") select post;
            var redditExternalPosts = from post in redditPosts where !post.Url.Contains("reddit.com") select post;

            var travelAdvisory = await _restService.GetTravelAdvisory(details);

            return BuildModel(
                details,
                BuildCity(
                    details,
                    DateTime.UtcNow.AddSeconds(utcOffset),
                    Math.Floor(Temperature.KelvinToCelsius(weatherResponse.Main.TemperatureInKelvin))),
                BuildAdvisory(travelAdvisory),
                images.Take(MAX_IMAGES).ToList(),
                redditInternalPosts.Take(6).ToList(),
                redditExternalPosts.Take(6).ToList());
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            var detailsList = await _restService.GetCountries();
            var models = from details in detailsList select BuildModel(details, null, null, null, null, null);
            return models.ToList();
        }

        private static CountryModel BuildModel(CountryDetailsModel details, CityModel capital, AdvisoryModel advisory,List<string> images, List<ExternalLink> reddit, List<ExternalLink> redditExt)
        {
            return new CountryModel
            {
                Name = details.Name,
                CapitalCity = capital,
                IsoCode = details.Iso3,
                Stub = details.Iso3,
                Images = images,
                RedditLinks = redditExt,
                RedditDiscussionLinks = reddit,
                TravelAdvisory = advisory
            };
        }

        private static CityModel BuildCity(CountryDetailsModel details, DateTime? localized, double degreesCelsius)
        {
            return new CityModel
            {
                Name = details.CapitalCity,
                LocalizedDateTime = localized.GetValueOrDefault(DateTime.UtcNow),
                DegreesInCelsius = degreesCelsius
            };
        }

        private static AdvisoryModel BuildAdvisory(AdvisoryResponse response)
        {
            return new AdvisoryModel
            {
                AdvisoryUrl = response.Data.Lang.En.UrlDetails,
                Description = response.Data.Lang.En.Advice,
                Rating = (int) Double.Parse(response.Data.Situation.Rating)
            };
        }

        private async Task<List<ExternalLink>> GetRedditPosts(CountryDetailsModel details)
        {
            if (_redditAuthorization == null || DateTime.UtcNow >= _refreshRedditTime)
            {
                _redditAuthorization = await _restService.AuthorizeReddit();
                _refreshRedditTime = DateTime.UtcNow.AddSeconds(_redditAuthorization.ExpiresIn / 2);
            }

            var response = await _restService.SearchReddit(String.Format("{0} travel", details.Name), _redditAuthorization);
            var children = from child in response.Data.Children
                           select new ExternalLink
                           {
                               Title = child.Data.Title,
                               Url = child.Data.Url
                           };

            return children.ToList();
        }
    }
}
