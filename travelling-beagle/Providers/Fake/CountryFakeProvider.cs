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
                },
                RedditLinks = new List<ExternalLink>
                {
                    new ExternalLink
                    {
                        Title = "What do you think of our Iceland Travel Itinerary?",
                        Url = "https://www.reddit.com/r/VisitingIceland/comments/6jgbz2/what_do_you_think_of_our_iceland_travel_itinerary/"
                    },
                    new ExternalLink
                    {
                        Title = "Anyone here used WOW to travel to Iceland (from EWR) Recently? Do they weigh?",
                        Url = "https://www.reddit.com/r/VisitingIceland/comments/6fmay9/anyone_here_used_wow_to_travel_to_iceland_from/"
                    },
                    new ExternalLink
                    {
                        Title = "Iceland travel places map with reviews and video footages",
                        Url = "https://www.reddit.com/r/VisitingIceland/comments/6ua47y/iceland_travel_places_map_with_reviews_and_video/"
                    },
                    new ExternalLink
                    {
                        Title = "Travel all the way around Iceland in 4 days? (Itinerary)",
                        Url = "https://www.reddit.com/r/VisitingIceland/comments/5h2j4t/travel_all_the_way_around_iceland_in_4_days/"
                    }
                },
                TravelBlogLinks = new List<ExternalLink>
                {
                    new ExternalLink
                    {
                        Title = "What do you think of our Iceland Travel Itinerary?",
                        Url = "https://www.reddit.com/r/VisitingIceland/comments/6jgbz2/what_do_you_think_of_our_iceland_travel_itinerary/"
                    },
                    new ExternalLink
                    {
                        Title = "Anyone here used WOW to travel to Iceland (from EWR) Recently? Do they weigh?",
                        Url = "https://www.reddit.com/r/VisitingIceland/comments/6fmay9/anyone_here_used_wow_to_travel_to_iceland_from/"
                    },
                    new ExternalLink
                    {
                        Title = "Iceland travel places map with reviews and video footages",
                        Url = "https://www.reddit.com/r/VisitingIceland/comments/6ua47y/iceland_travel_places_map_with_reviews_and_video/"
                    },
                    new ExternalLink
                    {
                        Title = "Travel all the way around Iceland in 4 days? (Itinerary)",
                        Url = "https://www.reddit.com/r/VisitingIceland/comments/5h2j4t/travel_all_the_way_around_iceland_in_4_days/"
                    }
                }
            }
        };

        public async Task<CountryModel> FindCountryByStub(string countryStub)
        {
            return countries.Find(c => c.Stub.Equals(countryStub));
        }
    }
}
