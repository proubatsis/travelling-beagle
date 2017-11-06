using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Caching
{
    public class DictCache : IBeagleCache
    {
        private Dictionary<string, CacheEntry> _dict;

        public DictCache()
        {
            _dict = new Dictionary<string, CacheEntry>();
        }

        public async Task Cache(string key, string value, double ttlSeconds)
        {
            if (key != null && value != null && ttlSeconds > 0.0)
            {
                var entry = new CacheEntry(value, ttlSeconds);
                if (_dict.ContainsKey(key))
                {
                    _dict[key] = entry;
                }
                else
                {
                    _dict.Add(key, entry);
                }
            }
        }

        public async Task<string> GetFromCache(string key)
        {
            if (_dict.ContainsKey(key) && _dict[key].IsValid)
            {
                return _dict[key].Value;
            }

            return null;
        }

        private class CacheEntry
        {
            private string _value;
            private DateTime _expiryUtc;

            public CacheEntry(string value, double ttlSeconds)
            {
                _value = value;
                _expiryUtc = DateTime.UtcNow.AddSeconds(ttlSeconds);
            }

            public bool IsValid
            {
                get
                {
                    return DateTime.UtcNow < _expiryUtc;
                }
            }

            public string Value
            {
                get
                {
                    return _value;
                }
            }
        }
    }
}
