using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TravellingBeagle.Models.External;
using TravellingBeagle.Util;

namespace TravellingBeagle.Services.External
{
    public class RestService : IRestService
    {
        private BeagleConfig config;

        public RestService(BeagleConfig config)
        {
            this.config = config;
        }

        public Task<List<CountryDetailsModel>> GetCountries()
        {
            return Get<List<CountryDetailsModel>>(String.Format(
                "{0}/{1}",
                config.ExtCountryServiceUrl,
                "all"
                ));
        }

        public Task<CountryDetailsModel> GetCountryDetails(string countryIso)
        {
            return Get<CountryDetailsModel>(String.Format(
                "{0}/{1}/{2}",
                config.ExtCountryServiceUrl,
                "alpha",
                countryIso));
        }

        private async static Task<T> Get<T>(string url)
        {
            var request = WebRequest.Create(url);
            var response = await request.GetResponseAsync();
            var reader = new StreamReader(response.GetResponseStream());
            var responseBody = await reader.ReadToEndAsync();
            reader.Close();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
