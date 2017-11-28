using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UI
    {
        //variables
        private string userInput;
        private bool isInputValid;

        public UI()
        {

        }

        //methods
        public void DisplayInitialMenu()
        {
            Console.WriteLine("Welcome to your very own Lemonade Stand!");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("START");
            Console.WriteLine("LOAD");
            Console.WriteLine("EXIT");
        }
        public void DisplayPlayerNameChangeMessage()
        {
            Console.WriteLine("What's your name?:");
        }
        public string GetUserInput(List<string> options, Game game)
        {
            Console.WriteLine("Please make a selection:");
            userInput = Console.ReadLine().ToLower();
            isInputValid = ValidateUserInput(userInput, options, game);
            if(!isInputValid)
            {
                GetUserInput(options, game);
            }
            return userInput;
        }

        private bool ValidateUserInput(string userInput, List<string> options, Game game)
        {
            if(options.Contains(userInput))
            {
                isInputValid = true;
                return isInputValid;
            }
            else
            {
                return isInputValid;
            }
        }
        private void DisplayErrorMessage()
        {
            Console.WriteLine("Input not recognized, please try again!");
            Console.ReadKey();
            Console.Clear();
            
        }
        public void DisplayPlayerSetNameSuccessMessage(Player player)
        {
            Console.WriteLine("Hello " + player.name + ", let's get this lemonade stand up and running!");
        }
        public void DisplayPlayerCurrentInfo(Player player)
        {
            Console.WriteLine("Alright, " + player.name + ", you currently have $" + player.money + " and nothing in your inventory.");
        }
        public void DisplayPlayerMenuExplanation()
        {
            //may need to include information about being able to choose 7 or greater days for timeframe of game
            Console.WriteLine("You will be able to take that starting fund and purchase necessary items such as Lemons,");
            Console.WriteLine("Sugar, Ice, and Cups from the STORE in order to make a quality product to sell to your thirsty customers!");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("You'll be able to generate your own RECIPE for lemonade from the supplies you purchased.");
            Console.WriteLine("You will begin with a default RECIPE, but you can make your own unique product and explore");
            Console.WriteLine("potential combinations to make a lemonade that your customers will absolutely crave, even in");
            Console.WriteLine("less favorable conditions!");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("However, you'll want to be aware of the WEATHER conditions of the day when making your");
            Console.WriteLine("business decisions. You have to take into account that customers may not have as great a");
            Console.WriteLine("thirst on cooler rainy days as they might on hotter sunny days.");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Need to step away from your thriving lemonade stand for now? No worries!");
            Console.WriteLine("You can SAVE your progress and return at a later time!");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("When you feel you're ready to start the business day, all you have to do is BEGIN");
            Console.WriteLine("and start selling your lemonade to the masses!");
        }
        public void DisplayBeginGameMessage()
        {
            Console.WriteLine("Time to get to work!");
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
        }
    }
}
