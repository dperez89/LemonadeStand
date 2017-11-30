using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        public Weather weather;
        public int dayNumber = 0;
        public List<Day> week = new List<Day> { };
        private int eightDays = 8;
        private int thirtyOneDays = 31;

        public Day(Random random)
        {
            weather = new Weather(random);
        }

        //methods
        public void GenerateSevenDays(Random random)
        {
            for(int i = 0; i < eightDays; i++)
            {
                week.Add(new Day(random));
                week.ElementAt(i).dayNumber = (i + 1);
            }
        }
        public void GenerateThirtyOneDays(Random random)
        {
            for (int i = 0; i < thirtyOneDays; i++)
            {
                week.Add(new Day(random));
                week.ElementAt(i).dayNumber = (i + 1);
            }
        }
    }
}
