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
        List<Customer> customers;
        Day day;
        PointOfSale pos;
        UI ui;
        Random random;
        List<string> initialMenuOptions = new List<string> { "start", "exit" };
        List<string> recipeMenuOptions = new List<string> { "1", "2", "3", "4", "5" }; 
        List<string> storeMenuOptions = new List<string> { "1", "2", "3", "4","5" };
        List<string> playerMenuOptions = new List<string> { "store", "recipe", "weather", "begin" };
        int numberOfDaysInGame = 7;
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

        //methods
        public void TestMethod(Game game) //INDEPENDENT METHOD FOR TESTING METHODS UNDER CONSTRUCTION
        {
            GenerateCustomers();
        }
        public void GenerateCustomers()
        {
            int j = random.Next(70, 130);
            for(int i = 0; i <= j; i++)
            {
                customers.Add(new Customer(random));
                Console.WriteLine(customers.ElementAt(i).willingnessToBuy);
            }
        }
        public void GetStartLoadOrExit(Game game)
        {
            ui.DisplayInitialMenu();
            string userInput = ui.GetUserInput(initialMenuOptions, game);
            switch (userInput)
            {
                case "start":
                    Console.Clear();
                    Console.WriteLine("You've started a game!");
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
            ui.DisplayPlayerSetNameSuccessMessage(player);
            ui.DisplayPlayerStartInfo(player);
            ui.DisplayPlayerMenuExplanation();
            ui.DisplayBeginGameMessage();
            day.GenerateSevenDays(random);
            for (int i = 0; day.week.ElementAt(i).dayNumber <= numberOfDaysInGame; i++)
            {
                beginIsSelected = false;
                while (!beginIsSelected)
                {
                    ui.DisplayCurrentPlayerAndDayInfo(player, day, day.week.ElementAt(i).dayNumber);
                    ui.DisplayPlayerMenu();
                    userInput = ui.GetUserInput(playerMenuOptions, game);
                    switch (userInput)
                    {
                        case "store":
                            store.SellToPlayer(player, ui, storeMenuOptions, game);
                            break;

                        case "recipe":
                            player.SetRecipe(ui, recipeMenuOptions, game);
                            break;

                        case "weather":
                            player.ViewWeather(ui, numberOfDaysInGame, day);
                            break;

                        case "begin":
                            GenerateCustomers();
                            pos.RunBusinessDay(day, day.week.ElementAt(i).weather.weather, customers, player, ui);
                            beginIsSelected = true;
                            break;
                    }
                    customers.Clear();
                }
                //***********END LOOP FOR PLAYER MENU WHEN 'BEGIN' IS SELECTED***********
                // Display results of the day (Day's number, Profit/Loss of the day, Profit/Loss of the game so far)
            }
            // ***********END LOOP FOR MAIN GAME WHEN NUMBER OF DAYS IN GAME IS SATISFIED***********
        }
    }
}
