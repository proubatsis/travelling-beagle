using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Extensions
{
    public static class DateTimeExtensions
    {
        public static long GetEpochTime(this DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (long)((dateTime - start).TotalSeconds);
        }
    }
}
