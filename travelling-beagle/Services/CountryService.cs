using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models;
using TravellingBeagle.Models.External;

namespace TravellingBeagle.Services
{
    public class CountryService : ICountryService
    {
        private IRestService restService;

        public CountryService(IRestService restService)
        {
            this.restService = restService;
        }

        public async Task<CountryModel> FindCountryByStub(string countryStub)
        {
            var details = await this.restService.GetCountryDetails(countryStub);
            return BuildModel(details, new List<string>(), new List<ExternalLink>(), new List<ExternalLink>());
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            var detailsList = await this.restService.GetCountries();
            var models = from details in detailsList select BuildModel(details, null, null, null);
            return models.ToList();
        }

        private static CountryModel BuildModel(CountryDetailsModel details, List<string> images, List<ExternalLink> reddit, List<ExternalLink> blog)
        {
            return new CountryModel
            {
                Name = details.Name,
                IsoCode = details.Iso3,
                Stub = details.Iso3,
                Images = images,
                RedditLinks = reddit,
                TravelBlogLinks = blog
            };
        }
    }
}
