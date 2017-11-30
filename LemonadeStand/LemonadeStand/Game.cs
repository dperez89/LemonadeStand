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
        UI ui;
        Random random;
        List<string> initialMenuOptions = new List<string> { "start", "load" };
        List<string> recipeMenuOptions = new List<string> { "1", "2", "3", "4" }; 
        List<string> storeMenuOptions = new List<string> { "1", "2", "3", "4","5" };
        List<string> playerMenuOptions = new List<string> { "store", "recipe", "weather", "begin" };
        int numberOfDaysInGame = 7; //NEEDS TO BE ASSIGNED BY THE PLAYER
        public Game()
        {
            random = new Random();
            player = new Player();
            day = new Day(random);
            store = new Store();
            customers = new List<Customer>();
            ui = new UI();
        }

        //methods
        public void TestMethod(Game game) //INDEPENDENT METHOD FOR TESTING METHODS UNDER CONSTRUCTION
        {

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
            // ***********BEGIN LOOP FOR MAIN GAME UNTIL NUMBER OF DAYS IN GAME IS SATISFIED***********
            for (int i = 0;  day.week.ElementAt(i).dayNumber < numberOfDaysInGame; i++)
            {
                beginIsSelected = false;
                while (!beginIsSelected)
                // ***********BEGIN LOOP FOR PLAYER MENU UNTIL 'BEGIN' IS SELECTED***********
                {
                    ui.DisplayCurrentPlayerAndDayInfo(player, day, day.week.ElementAt(i).dayNumber); // does not currently report accurate DayNumber
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

                            break;

                        case "begin":
                            beginIsSelected = true;
                            break;
                    }
                // display menu options ::relative to methods::
                    // STORE / RECIPE / WEATHER / BEGIN

                        //BEGIN
                            //generate customers
                            //have each customer evaluated against recipe and lemonade price values to determine
                              //either the success of a sale or if the customer doesn't buy any lemonade.
                }
                //***********END LOOP FOR PLAYER MENU WHEN 'BEGIN' IS SELECTED***********
                // Display results of the day (Day's number, Profit/Loss of the day, Profit/Loss of the game so far)
            }
            // ***********END LOOP FOR MAIN GAME WHEN NUMBER OF DAYS IN GAME IS SATISFIED***********
        }
    }
}
