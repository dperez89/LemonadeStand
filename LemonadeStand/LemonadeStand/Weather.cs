using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public int rainyWeatherMod = -10;
        public int sunnyWeatherMod = 10;
        public int overcastWeatherMod = 0;
        public double temperatureMod = .10;
        public int temperature;
        public int weatherNumber;
        public string weather;
        public List<string> weathers = new List<string> { "Rainy", "Sunny", "Overcast" };


        public Weather(Random random)
        {
            SetWeather(random);
            SetTemperature(random);
        }
        public void SetWeather(Random random)
        {
            weatherNumber = random.Next(0, weathers.Count);
            weather = weathers.ElementAt(weatherNumber);
        }
        private void SetTemperature(Random random)
        {
            temperature = random.Next(35, 101);
        }
    }
}
