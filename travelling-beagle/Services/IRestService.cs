using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models.External;
using TravellingBeagle.Models.External.Google.GeoCode;

namespace TravellingBeagle.Services
{
    public interface IRestService
    {
        Task<List<CountryDetailsModel>> GetCountries();
        Task<CountryDetailsModel> GetCountryDetails(string countryIso);
        Task<List<string>> GetImageUrls(string q);
        Task<Coordinates> GetCoordinates(CountryDetailsModel details);
        Task<double> GetUtcOffsetAtCoordinates(double longitude, double latitude);
    }
}
