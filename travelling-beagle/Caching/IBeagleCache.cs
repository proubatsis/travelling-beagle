using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Caching
{
    public interface IBeagleCache
    {
        Task Cache(string key, string value, double ttlSeconds);
        Task<string> GetFromCache(string key);
    }
}
