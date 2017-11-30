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
        public void SetRecipe(UI ui, List<string> options, Game game)
        {
            string userInput;

            ui.DisplayRecipeMenu(this);
            userInput = ui.GetUserInput(options, game);
            switch(userInput)
            {
                case "1":
                    recipe.SetLemonsAmount();
                    break;

                case "2":
                    recipe.SetSugarsAmount();
                    break;

                case "3":
                    recipe.SetIceAmount();
                    break;

                case "4":
                    break;
            }
        }
    }
}
