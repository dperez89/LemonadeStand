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
            Console.WriteLine("EXIT");
        }
        public void DisplayPlayerNameChangeMessage()
        {
            Console.WriteLine("What's your name?:");
        }
        public string GetUserInput(List<string> options, Game game)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Please make a selection:");
            userInput = Console.ReadLine().ToLower();
            isInputValid = ValidateUserInput(userInput, options, game);
            if(!isInputValid)
            {
                GetUserInput(options, game);
            }
            return userInput;
        }
        public string GetUserQuantityInput()
        {
            Console.WriteLine("Please enter a quantity");
            userInput = Console.ReadLine();
            isInputValid = ValidateUserQuantityInput(userInput);
            if (!isInputValid)
            {
                GetUserQuantityInput();
            }
            return userInput;
        }

        private bool ValidateUserInput(string userInput, List<string> options, Game game)
        {
            isInputValid = false;
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
        private bool ValidateUserQuantityInput(string userInput)
        {
            isInputValid = false;
            int i;
            if (Int32.TryParse(userInput, out i))
            {
                isInputValid = true;
                return isInputValid;
            }
            else
            {
                return isInputValid;
            }
        }
        public int ConvertStringToNumber(string userInput, int userQuantity)
        {
            userQuantity = Int32.Parse(userInput);
            return userQuantity;
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
            Console.WriteLine(Environment.NewLine);
        }
        public void DisplayPlayerStartInfo(Player player)
        {
            Console.WriteLine("Alright, " + player.name + ", you currently have $" + player.Money + " and nothing in your inventory.");
            Console.WriteLine(Environment.NewLine);
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
            Console.WriteLine("When you feel you're ready to start the business day, all you have to do is BEGIN");
            Console.WriteLine("and start selling your lemonade to the masses!");
        }

        internal void DisplayResultsOfTheDay(Player player, PointOfSale pos, Game game)
        {
            Console.WriteLine("TODAY'S RESULTS");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("You sold lemonade to " + pos.SuccessfulSales + " out of " + game.customers.Count + " potential customers.");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("You spent a total of $" + player.MoneySpentToday + " today.");
            Console.WriteLine("You earned a total of $" + pos.AmountMadeInSalesToday + " today");
            if (player.TotalMoneyEarned > player.TotalMoneySpent)
            {
                Console.WriteLine("Your lemonade stand has ultimately experienced a profit of $" + (player.TotalMoneyEarned - player.TotalMoneySpent) + " since the start of your business");
            }
            else if (player.TotalMoneyEarned < player.TotalMoneySpent)
            {
                Console.WriteLine("Your lemonade stand has ultimately experienced a loss of $" + (player.TotalMoneySpent - player.TotalMoneyEarned) + " since the start of your business");
            }
        }

        public void DisplayBeginGameMessage()
        {
            Console.WriteLine("Time to get to work!");
        }
        public void DisplayCurrentPlayerAndDayInfo(Player player, Day day)
        {
            Console.WriteLine("Player: " + player.name);
            Console.WriteLine("Money: $" + player.Money);
            Console.WriteLine("Day: " + day.dayNumber);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("WEATHER");
            Console.WriteLine("Type: " + day.weather.weather);
            Console.WriteLine("Temperature: " + day.weather.temperature);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("INVENTORY");
            Console.WriteLine("Lemons: " + player.inventory.lemons.Count);
            Console.WriteLine("Sugars: " + player.inventory.sugars.Count);
            Console.WriteLine("Ice Cubes: " + player.inventory.ice.Count);
            Console.WriteLine("Cups: " + player.inventory.cups.Count);
            Console.WriteLine(Environment.NewLine);
        }
        public void DisplayPlayerMenu()
        {
            Console.WriteLine("STORE - make sure to buy what you need!");
            Console.WriteLine("RECIPE - use your ingredients to make the best lemonade in town!");
            Console.WriteLine("WEATHER - keep a track of the weather to make the best decisions!");
            Console.WriteLine("BEGIN - get the day started and make some money!");
        }
        public void DisplayStoreMenu(Store store, Player player)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Store!");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("You currently have $" + player.Money);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("1.) Lemons - $" + store.lemons.purchasePrice + "       You currently have " + player.inventory.lemons.Count + " lemons.");
            Console.WriteLine("2.) Sugar - $" + store.sugars.purchasePrice + "        You currently have " + player.inventory.sugars.Count + " sugars.");
            Console.WriteLine("3.) Ice Cubes - $" + store.ice.purchasePrice + "    You currently have " + player.inventory.ice.Count + " ice cubes.");
            Console.WriteLine("4.) Cups - $" + store.cups.purchasePrice + "         You currently have " + player.inventory.cups.Count + " cups.");
            Console.WriteLine("5.) Exit");
        }
        public void DisplayDesiredQuantityRequest()
        {
            Console.WriteLine("How many would you like to buy?");
            Console.WriteLine(Environment.NewLine);
        }
        public void DisplayRecipeMenu(Player player)
        {
            Console.WriteLine("RECIPE INFORMATION");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("You can change the amount of the listed ingredients here. You can choose an ingredient by its number.");
            Console.WriteLine("1.) Lemons: " + player.recipe.Lemons);
            Console.WriteLine("2.) Sugars: " + player.recipe.Sugars);
            Console.WriteLine("3.) Ice Cubes: " + player.recipe.Ice);
            Console.WriteLine("4.) Your Current Price: " + player.recipe.LemonadePrice);
            Console.WriteLine("5.) Exit");
            Console.WriteLine(Environment.NewLine);
        }
        public void DisplayWeatherForecast(Day day, int numberOfDaysInGame)
        {
            Console.WriteLine("WEATHER FORECAST");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Here is the weather for the next seven days:");
            Console.WriteLine(Environment.NewLine);

            for (int i = 0; day.week.ElementAt(i).dayNumber <= numberOfDaysInGame; i++ )
            {
                Console.WriteLine("Day: " + day.week.ElementAt(i).dayNumber);
                Console.WriteLine("Temperature: " + day.week.ElementAt(i).weather.temperature);
                Console.WriteLine("Weather Type: " + day.week.ElementAt(i).weather.weather);
                Console.WriteLine(Environment.NewLine);
            }
            Console.ReadKey();
        }
        public void DisplayPressAnyKeyToContinue()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
        public void DisplayEndOfGame(Player player)
        {
            Console.WriteLine("It would appear you've run out of time!");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("THANKS FOR PLAYING!");

        }
    }
}
