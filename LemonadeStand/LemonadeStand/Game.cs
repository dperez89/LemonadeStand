using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player;
        Store store;        
        Day day;
        PointOfSale pos;
        UI ui;
        Random random;
        public List<Customer> customers;
        private List<string> initialMenuOptions = new List<string> { "start", "exit" };
        private List<string> recipeMenuOptions = new List<string> { "1", "2", "3", "4", "5" }; 
        private List<string> storeMenuOptions = new List<string> { "1", "2", "3", "4","5" };
        private List<string> playerMenuOptions = new List<string> { "store", "recipe", "weather", "begin" };
        private int numberOfDaysInGame = 7;
        public List<string> InitialMenuOptions
        {
            get
            {
                return initialMenuOptions;
            }
        }
        public List<string> RecipeMenuOptions
        {
            get
            {
                return recipeMenuOptions;
            }
        }
        public List<string> StoreMenuOptions
        {
            get
            {
                return storeMenuOptions;
            }
        }
        public List<string> PlayerMenuOptions
        {
            get
            {
                return playerMenuOptions;
            }
        }
        public Game()
        {
            random = new Random();
            player = new Player();
            day = new Day(random);
            pos = new PointOfSale();
            store = new Store();
            customers = new List<Customer>();
            ui = new UI();
        }

        public void GenerateCustomers()
        {
            int j = random.Next(70, 130);
            for(int i = 0; i < j; i++)
            {
                customers.Add(new Customer(random));
            }
        }
        public void GetStartLoadOrExit(Game game)
        {
            ui.DisplayInitialMenu();
            string userInput = ui.GetUserInput(InitialMenuOptions, game);
            switch (userInput)
            {
                case "start":
                    Console.Clear();
                    Console.WriteLine("You've started a game!");
                    Console.WriteLine(Environment.NewLine);
                    RunGame(game);
                    break;

                case "exit":
                    Console.Clear();
                    Console.WriteLine("You've exited the game!");
                    break;
            }
        }
        private void RunGame(Game game)
        {
            bool beginIsSelected;
            string userInput;

            player.SetName(ui);
            Console.Clear();
            ui.DisplayPlayerSetNameSuccessMessage(player);
            ui.DisplayPlayerStartInfo(player);
            ui.DisplayPlayerMenuExplanation();
            Console.WriteLine(Environment.NewLine);
            ui.DisplayBeginGameMessage();
            ui.DisplayPressAnyKeyToContinue();
            Console.Clear();
            day.GenerateSevenDays(random);
            for (int i = 0; day.week.ElementAt(i).dayNumber <= numberOfDaysInGame; i++)
            {
                beginIsSelected = false;
                while (!beginIsSelected)
                {
                    ui.DisplayCurrentPlayerAndDayInfo(player, day.week.ElementAt(i));
                    ui.DisplayPlayerMenu();
                    userInput = ui.GetUserInput(PlayerMenuOptions, game);
                    switch (userInput)
                    {
                        case "store":
                            store.SellToPlayer(player, ui, StoreMenuOptions, game);
                            break;

                        case "recipe":
                            player.SetRecipe(ui, RecipeMenuOptions, game);
                            break;

                        case "weather":
                            player.ViewWeather(ui, numberOfDaysInGame, day);
                            break;

                        case "begin":
                            player.recipe.SetRecipeGrade();
                            GenerateCustomers();
                            pos.RunBusinessDay(day, day.week.ElementAt(i).weather.weather, customers, player, ui);
                            beginIsSelected = true;
                            Console.Clear();
                            ui.DisplayResultsOfTheDay(player, pos, game);
                            player.ResetMoneySpentToday();
                            ui.DisplayPressAnyKeyToContinue();
                            break;
                    }
                    customers.Clear();
                    Console.Clear();
                }
            }
            ui.DisplayEndOfGame(player);
        }
    }
}
