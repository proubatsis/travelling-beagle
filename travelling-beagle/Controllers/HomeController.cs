using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravellingBeagle.Models;
using TravellingBeagle.Providers;

namespace TravellingBeagle.Controllers
{
    public class HomeController : Controller
    {
        private ICountryProvider countryProvider;

        public HomeController(ICountryProvider countryProvider)
        {
            this.countryProvider = countryProvider;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await countryProvider.GetCountries();
            return View(countries);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
