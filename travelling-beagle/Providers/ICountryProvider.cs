using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models;

namespace TravellingBeagle.Providers
{
    public interface ICountryProvider
    {
        Task<CountryModel> FindCountryByStub(string countryStub);
    }
}
