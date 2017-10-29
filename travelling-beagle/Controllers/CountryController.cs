using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravellingBeagle.Models;
using TravellingBeagle.Providers;

namespace TravellingBeagle.Controllers
{
    [Route("country")]
    public class CountryController : Controller
    {
        private ICountryProvider countryProvider;

        public CountryController(ICountryProvider countryProvider)
        {
            this.countryProvider = countryProvider;
        }

        [Route("{stub}")]
        public async Task<IActionResult> Index(string stub)
        {
            var country = await countryProvider.FindCountryByStub(stub);
            
            if (country != null)
            {
                return View(country);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
