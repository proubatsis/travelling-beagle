using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellingBeagle.Util
{
    public class Temperature
    {
        private static double ZERO_CELSIUS_IN_KELVIN = 273.15;

        public static double KelvinToCelsius(double kelvin)
        {
            return kelvin - ZERO_CELSIUS_IN_KELVIN;
        }
    }
}
