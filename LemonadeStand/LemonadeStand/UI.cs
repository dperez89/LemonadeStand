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

        private bool ValidateUserInput(string userInput, List<string> initialMenuOptions, Game game)
        {
            if(initialMenuOptions.Contains(userInput))
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
    }
}
