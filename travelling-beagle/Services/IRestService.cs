using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models.External;

namespace TravellingBeagle.Services
{
    public interface IRestService
    {
        Task<List<CountryDetailsModel>> GetCountries();
        Task<CountryDetailsModel> GetCountryDetails(string countryIso);
        Task<List<string>> GetImageUrls(string q);
    }
}
