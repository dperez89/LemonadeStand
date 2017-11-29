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
        public Inventory inventory;
        public Recipe recipe;
        public int money = 100;

        public Player()
        {
            inventory = new Inventory();
        }

        //methods
        public void SetName(UI ui)
        {
            ui.DisplayPlayerNameChangeMessage();
            name = Console.ReadLine();
        }
    }
}
