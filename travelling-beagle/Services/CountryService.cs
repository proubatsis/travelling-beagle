using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models;
using TravellingBeagle.Models.Country;
using TravellingBeagle.Models.External;
using TravellingBeagle.Util;

namespace TravellingBeagle.Services
{
    public class CountryService : ICountryService
    {
        private IRestService restService;
        private static int MAX_IMAGES = 9;

        public CountryService(IRestService restService)
        {
            this.restService = restService;
        }

        public async Task<CountryModel> FindCountryByStub(string countryStub)
        {
            var details = await this.restService.GetCountryDetails(countryStub);
            var images = await this.restService.GetImageUrls(details.Name);

            var coord = await this.restService.GetCoordinates(details);
            var utcOffset = await this.restService.GetUtcOffsetAtCoordinates(coord.Longitude, coord.Latitude);

            var weatherResponse = await this.restService.GetWeatherAtCoordinates(coord.Longitude, coord.Latitude);

            return BuildModel(
                details,
                BuildCity(
                    details,
                    DateTime.UtcNow.AddSeconds(utcOffset),
                    Math.Floor(Temperature.KelvinToCelsius(weatherResponse.Main.TemperatureInKelvin))),
                images.Take(MAX_IMAGES).ToList(),
                new List<ExternalLink>(),
                new List<ExternalLink>());
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            var detailsList = await this.restService.GetCountries();
            var models = from details in detailsList select BuildModel(details, null, null, null, null);
            return models.ToList();
        }

        private static CountryModel BuildModel(CountryDetailsModel details, CityModel capital, List<string> images, List<ExternalLink> reddit, List<ExternalLink> blog)
        {
            return new CountryModel
            {
                Name = details.Name,
                CapitalCity = capital,
                IsoCode = details.Iso3,
                Stub = details.Iso3,
                Images = images,
                RedditLinks = reddit,
                TravelBlogLinks = blog
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
    }
}
