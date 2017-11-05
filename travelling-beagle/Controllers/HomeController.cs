using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravellingBeagle.Models;
using TravellingBeagle.Services;

namespace TravellingBeagle.Controllers
{
    public class HomeController : Controller
    {
        private ICountryService countryService;

        public HomeController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await countryService.GetCountries();
            return View(countries);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
