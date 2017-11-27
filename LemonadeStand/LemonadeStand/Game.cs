using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player1;
        Store store;
        List<Customer> customers;
        Day day;
        UI ui;
        List<string> initialMenuOptions = new List<string> { "start", "load", "exit" };
        public Game()
        {
            player1 = new Player();
            store = new Store();
            customers = new List<Customer>();
            day = new Day();
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
                    RunGame();
                    break;

                case "load":
                    Console.Clear();
                    Console.WriteLine("You've Loaded a game!");
                    break;

                case "exit":
                    Console.Clear();
                    Console.WriteLine("You've exited the game!");
                    break;
            }
        }

        private void SetPlayerName()
        {
            ui.DisplayPlayerNameChangeMessage();
            player1.SetName();
        }
        private void RunGame()
        {
            SetPlayerName();
            Console.WriteLine("You have set your player name to " + player1.name);

        }
    }
}
