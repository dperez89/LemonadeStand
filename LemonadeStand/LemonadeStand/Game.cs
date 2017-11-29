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
        public void GetStartLoadOrExit(Game game)
        {
            ui.DisplayInitialMenu();
            string userInput = ui.GetUserInput(initialMenuOptions, game);
            switch (userInput)
            {
                case "start":
                    Console.Clear();
                    Console.WriteLine("You've started a game!");
                    //RunGame();
                    day.GenerateThirtyOneDays(random);
                    ui.DisplayCurrentPlayerAndDayInfo(player, day);
                    ui.DisplayPlayerMenu();
                    Console.ReadKey();
                    break;

                case "exit":
                    Console.Clear();
                    Console.WriteLine("You've exited the game!");
                    break;
            }
        }
        private void RunGame()
        {
            player.SetName(ui);
            ui.DisplayPlayerSetNameSuccessMessage(player);
            ui.DisplayPlayerStartInfo(player);
            ui.DisplayPlayerMenuExplanation();
            ui.DisplayBeginGameMessage();
            // ***********BEGIN LOOP FOR MAIN GAME UNTIL NUMBER OF DAYS IN GAME IS SATISFIED***********
            while (day.dayNumber <= numberOfDaysInGame)
            {
                while (true)
                // ***********BEGIN LOOP FOR PLAYER MENU UNTIL 'BEGIN' IS SELECTED***********
                {
                    ui.DisplayCurrentPlayerAndDayInfo(player, day); // does not currently report accurate DayNumber
                    ui.DisplayPlayerMenu();
                // display menu options ::relative to methods::
                    // STORE / RECIPE / WEATHER / BEGIN
                        //STORE
                            //Display inventory items and their prices
                            //BUY option
                                //adds to player inventory, reduces player money
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
