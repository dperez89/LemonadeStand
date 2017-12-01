using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        public int willingnessToBuy;


        public Customer(Random random)
        {
            willingnessToBuy = GenerateWillingnessToBuy(random);
        }

        //methods
        private int GenerateWillingnessToBuy(Random random)
        {
            int i;

            i = random.Next(30, 70);
            return i;
        }
    }
}
