using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public string name;
        Inventory inventory;
        Recipe recipe;
        int money;

        public Player()
        {

        }

        //methods
        public void SetName(UI ui)
        {
            ui.DisplayPlayerNameChangeMessage();
            name = Console.ReadLine();
        }
    }
}
