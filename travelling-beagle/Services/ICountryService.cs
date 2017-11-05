using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models;

namespace TravellingBeagle.Services
{
    public interface ICountryService
    {
        Task<List<CountryModel>> GetCountries();
        Task<CountryModel> FindCountryByStub(string countryStub);
    }
}
