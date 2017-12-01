using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        private int totalMoneySpent;
        private int totalMoneyEarned;
        private int moneySpentToday;
        public string name;
        public Inventory inventory;
        public Recipe recipe;
        private int money = 100;

        public int TotalMoneySpent
        {
            get
            {
                return totalMoneySpent;            
            }
            set
            {
                totalMoneySpent = value;
            }
        }
        public int TotalMoneyEarned
        {
            get
            {
                return totalMoneyEarned;
            }
            set
            {
                totalMoneyEarned = value;
            }
        }
        public int MoneySpentToday
        {
            get
            {
                return moneySpentToday;
            }
            set
            {
                moneySpentToday = value;
            }
        }
        public int Money
        {
            get
            {
                return money;           
            }
            set
            {
                money = value;
            }
        }

        public Player()
        {
            inventory = new Inventory();
            recipe = new Recipe();
        }

        //methods
        public void SetName(UI ui)
        {
            ui.DisplayPlayerNameChangeMessage();
            name = Console.ReadLine();
        }
        public void ViewWeather(UI ui, int numberOfDaysInGame, Day day)
        {
            ui.DisplayWeatherForecast(day, numberOfDaysInGame);
        }
        public void SetRecipe(UI ui, List<string> options, Game game)
        {
            string userInput;
            int userQuantityInput = 0;
            bool exitIsSelected = false;

            while (!exitIsSelected)
            {
                Console.Clear();
                ui.DisplayRecipeMenu(this);
                userInput = ui.GetUserInput(options, game);
                    switch (userInput)
                    {
                        case "1":
                            userInput = ui.GetUserQuantityInput();
                            userQuantityInput = ui.ConvertStringToNumber(userInput, userQuantityInput);
                            SetLemonsAmount(userQuantityInput);
                            break;

                        case "2":
                            userInput = ui.GetUserQuantityInput();
                            userQuantityInput = ui.ConvertStringToNumber(userInput, userQuantityInput);
                            SetSugarsAmount(userQuantityInput);
                            break;

                        case "3":
                            userInput = ui.GetUserQuantityInput();
                            userQuantityInput = ui.ConvertStringToNumber(userInput, userQuantityInput);
                            SetIceAmount(userQuantityInput);
                            break;

                        case "4":
                            userInput = ui.GetUserQuantityInput();
                            userQuantityInput = ui.ConvertStringToNumber(userInput, userQuantityInput);
                            SetLemonadePrice(userQuantityInput);
                            break;

                        case "5":
                                exitIsSelected = true;
                                break;
                }
            }
        }
        private void SetLemonsAmount(int userQuantityInput)
        {
            recipe.Lemons = userQuantityInput;
        }
        private void SetSugarsAmount(int userQuantityInput)
        {
            recipe.Sugars = userQuantityInput;
        }
        private void SetIceAmount(int userQuantityInput)
        {
            recipe.Ice = userQuantityInput;
        }
        private void SetLemonadePrice(int userQuantityInput)
        {
            recipe.LemonadePrice = userQuantityInput;
        }
        public void ResetMoneySpentToday()
        {
            MoneySpentToday = 0;
        }
    }
}
