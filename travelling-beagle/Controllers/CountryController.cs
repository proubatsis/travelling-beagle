using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravellingBeagle.Models;
using TravellingBeagle.Services;

namespace TravellingBeagle.Controllers
{
    [Route("country")]
    public class CountryController : Controller
    {
        private ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [Route("{stub}")]
        public async Task<IActionResult> Index(string stub)
        {
            var country = await countryService.FindCountryByStub(stub);
            
            if (country != null)
            {
                return View(country);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("all.json")]
        public async Task<IActionResult> AllCountries()
        {
            var countries = await countryService.GetCountries();
            return Ok(countries);
        }
    }
}
