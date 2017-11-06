using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingBeagle.Models;

namespace TravellingBeagle.Services.Fake
{
    public class CountryFakeService : ICountryService
    {
        private List<CountryModel> countries = new List<CountryModel>
        {
            new CountryModel
            {
                IsoCode = "ISL",
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
                RedditDiscussionLinks = new List<ExternalLink>
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
            },
            new CountryModel
            {
                IsoCode = "MAR",
                Stub = "morocco",
                Name = "Morocco",
                Images = new List<string>
                {
                    "https://www.intrepidtravel.com/sites/intrepid/files/styles/low-quality/public/elements/product/hero/morocco_essaouria_blue-building-entrance.jpg",
                    "https://media.gadventures.com/media-server/image_library/3868293_1080x810_Ait_Ben_Haddou_Morocco.jpg",
                    "https://cdn.theculturetrip.com/wp-content/uploads/2015/11/Morocco-%C2%A9-cdrin-Shutterstock-650x434.jpg",
                    "https://media.cntraveler.com/photos/57ed6c2c964452525af6cc22/16:9/w_1024,c_limit/Exterior-PalaisAmani-FezMorocco-CRHotel.jpg",
                    "https://cdn.worldnomads.net/Media/Default/social-share-images/morocco/morocco-scams-social.jpg",
                    "http://www.thehomesmatchmaker.com/wp-content/uploads/2016/06/morocco.jpg",
                    "https://cdn.tourradar.com/s3/tour/original/74819_64c6cfe7.jpg",
                    "https://www.intrepidtravel.com/sites/intrepid/files/styles/low-quality/public/elements/product/hero/morocco_fes_nuts-market-stall.jpg",
                    "http://cdn.newsapi.com.au/image/v1/bc9869520fd9ce2c1e72f06954dd0a31?width=1024"
                },
                RedditLinks = new List<ExternalLink>
                {
                    new ExternalLink
                    {
                        Title = "[Travel] Morocco itinerary Suggestions",
                        Url = "https://www.reddit.com/r/Morocco/comments/66whga/travel_morocco_itinerary_suggestions/"
                    },
                    new ExternalLink
                    {
                        Title = "Weekly Thread For Travel Related Questions & Discussions - May 20, 2017",
                        Url = "https://www.reddit.com/r/Morocco/comments/6c7ej1/weekly_thread_for_travel_related_questions/"
                    },
                    new ExternalLink
                    {
                        Title = "Morocco - Travel Vid",
                        Url = "https://www.reddit.com/r/Morocco/comments/6s0vz8/morocco_travel_vid/"
                    },
                    new ExternalLink
                    {
                        Title = "Anyone been on Morocco?",
                        Url = "https://www.reddit.com/r/travel/comments/5xwiz7/anyone_been_on_morocco/"
                    }
                },
                RedditDiscussionLinks = new List<ExternalLink>
                {
                    new ExternalLink
                    {
                        Title = "[Travel] Morocco itinerary Suggestions",
                        Url = "https://www.reddit.com/r/Morocco/comments/66whga/travel_morocco_itinerary_suggestions/"
                    },
                    new ExternalLink
                    {
                        Title = "Weekly Thread For Travel Related Questions & Discussions - May 20, 2017",
                        Url = "https://www.reddit.com/r/Morocco/comments/6c7ej1/weekly_thread_for_travel_related_questions/"
                    },
                    new ExternalLink
                    {
                        Title = "Morocco - Travel Vid",
                        Url = "https://www.reddit.com/r/Morocco/comments/6s0vz8/morocco_travel_vid/"
                    },
                    new ExternalLink
                    {
                        Title = "Anyone been on Morocco?",
                        Url = "https://www.reddit.com/r/travel/comments/5xwiz7/anyone_been_on_morocco/"
                    }
                }
            }
        };

        public async Task<CountryModel> FindCountryByStub(string countryStub)
        {
            return countries.Find(c => c.Stub.Equals(countryStub));
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            return countries;
        }
    }
}
