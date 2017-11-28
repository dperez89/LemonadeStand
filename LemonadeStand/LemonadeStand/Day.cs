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
        public int dayNumber = 1;

        public Day(Random random)
        {
            weather = new Weather(random);
        }

        //methods
    }
}
