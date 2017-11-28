﻿using System;
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
        List<string> initialMenuOptions = new List<string> { "start", "load", "exit" };
        int numberOfDaysInGame = 7; //NEEDS TO BE ASSIGNED BY THE PLAYER
        public Game()
        {
            player = new Player();
            store = new Store();
            customers = new List<Customer>();
            ui = new UI();
            random = new Random();
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
                    day = new Day(random);
                    Console.WriteLine(day.weather.weather);
                    Console.WriteLine(day.weather.customerGenMod);
                    Console.WriteLine(day.weather.temperature);
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
        private void RunGame()
        {
            player.SetName(ui);
            ui.DisplayPlayerSetNameSuccessMessage(player);
            ui.DisplayPlayerCurrentInfo(player);
            ui.DisplayPlayerMenuExplanation();
            ui.DisplayBeginGameMessage();
            // ***********BEGIN LOOP FOR MAIN GAME UNTIL NUMBER OF DAYS IN GAME IS SATISFIED***********
            while (day.dayNumber <= numberOfDaysInGame)
            {
                while (true)
                // ***********BEGIN LOOP FOR PLAYER MENU UNTIL 'BEGIN' IS SELECTED***********
                {
                // display information needed by the player (Day's number, day's weather, current inventory, current money
                    // & current recipe)
                // display menu options ::relative to methods::
                    // STORE / RECIPE / WEATHER / SAVE / BEGIN
                        //WEATHER
                            //View next day's weather or the week's weather
                        //STORE
                            //Display inventory items and their prices
                            //BUY option
                                //adds to player inventory, reduces player money
                        //RECIPE
                            //CHANGE inventory item amounts for recipe
                        //SAVE
                            //Saves game through SQLConnect method.
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
