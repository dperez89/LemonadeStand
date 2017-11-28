using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public int customerGenMod;
        public int temperature;
        public int weatherNumber;
        public string weather;
        List<string> weathers = new List<string> { "Rainy", "Sunny", "Overcast" };
        List<int> weatherCustomerGenMods = new List<int> { -10, 10, 0 };


        public Weather(Random random)
        {
            weather = GetWeather(random);
            SetCustomerGenMod(weather, weathers, weatherCustomerGenMods);
        }
        public string GetWeather(Random random)
        {
            weatherNumber = random.Next(0, weathers.Count);
            weather = weathers.ElementAt(weatherNumber);
            return weather;
        }
        private void SetCustomerGenMod(string weather, List<string> weathers, List<int> weatherCustomerGenMods)
        {
            for (int i = 0; i < weathers.Count; i++)
            {
                if (weather == weathers.ElementAt(i))
                {
                    customerGenMod = weatherCustomerGenMods.ElementAt(i);
                    break;
                }
            }           
        }
    }
}
