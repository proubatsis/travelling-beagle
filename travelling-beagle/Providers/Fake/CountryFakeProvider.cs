using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models;

namespace TravellingBeagle.Providers.Fake
{
    public class CountryFakeProvider : ICountryProvider
    {
        private List<CountryModel> countries = new List<CountryModel>
        {
            new CountryModel
            {
                Stub = "iceland",
                Name = "Iceland",
                Images = new List<string>
                {
                    "https://s3-eu-west-1.amazonaws.com/originaltravel.assets.d3r.com/images/hero_xlarge/269575-northern-lights-iceland.jpg",
                    "http://www.telegraph.co.uk/content/dam/Travel/Destinations/Europe/Iceland/iceland-main-AP-xlarge.jpg",
                    "http://www.cheapflightslab.com/wp-content/uploads/2017/04/iceland_blue-lagoon-bathers_0.jpg.pagespeed.ce_.wmkYtS_enm.jpg",
                    "http://cdn.cnn.com/cnnnext/dam/assets/170320114320-01-iceland-pools-culture-exlarge-169.jpg",
                    "https://www.reykjavikauto.com/driving-iceland-home.jpg",
                    "https://guidetoiceland.is/image/317571/x/0/2-is.jpg",
                    "http://cdn.cnn.com/cnnnext/dam/assets/170612142802-04-best-of-iceland-full-169.jpg",
                    "https://icelandunlimited.is/wp-content/uploads/2016/10/iceland-winter-package.jpg",
                    "https://www.pandotrip.com/wp-content/uploads/2014/04/Iceland-Hallgrimskirkja-Photo-by-Mitch-Russo-740x570.jpg"
                }
            }
        };

        public async Task<CountryModel> FindCountryByStub(string countryStub)
        {
            return countries.Find(c => c.Stub.Equals(countryStub));
        }
    }
}
