using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        public Lemon lemons;
        public Ice ice;
        public Sugar sugars;
        public Cup cups;
        public string userInput;
        private int userInputQuantity;
        bool doesPlayerHaveEnoughMoney;

        public Store()
        {
            lemons = new Lemon();
            ice = new Ice();
            sugars = new Sugar();
            cups = new Cup();
        }
        public void SellToPlayer(Player player, UI ui, List<string> options, Game game)
        {
            ui.DisplayStoreMenu(this, player);
            userInput = ui.GetUserInput(options, game);
            switch(userInput)
            {
                case "1":
                    SellLemons(player, ui);
                    break;

                case "2":
                    SellSugar(player, ui);
                    break;

                case "3":
                    SellIce(player, ui);
                    break;

                case "4":
                    SellIce(player, ui);
                    break;

                case "5":
                    break;
            }

        }
        public void SellLemons(Player player, UI ui)
        {
            ui.DisplayDesiredQuantityRequest();
            userInput = ui.GetUserStorePurchaseInput();
            userInputQuantity = ui.ConvertStringToNumber(userInput, userInputQuantity);
            doesPlayerHaveEnoughMoney = ValidatePriceToPlayerMoney(player, userInputQuantity, lemons.purchasePrice);
            if(doesPlayerHaveEnoughMoney)
            {
                for (int i = 1; i <= userInputQuantity; i++)
                {
                    player.money -= lemons.purchasePrice;
                    player.inventory.lemons.Add(new Lemon());
                }
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.ReadKey();
            }
        }
        public void SellSugar(Player player, UI ui)
        {
            ui.DisplayDesiredQuantityRequest();
            userInput = ui.GetUserStorePurchaseInput();
            userInputQuantity = ui.ConvertStringToNumber(userInput, userInputQuantity);
            doesPlayerHaveEnoughMoney = ValidatePriceToPlayerMoney(player, userInputQuantity, sugars.purchasePrice);
            if (doesPlayerHaveEnoughMoney)
            {
                for (int i = 1; i <= userInputQuantity; i++)
                {
                    player.money -= sugars.purchasePrice;
                    player.inventory.sugars.Add(new Sugar());
                    player.inventory.sugars.Add(new Sugar());
                    player.inventory.sugars.Add(new Sugar());
                }
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.ReadKey();
            }
        }
        public void SellIce(Player player, UI ui)
        {
            ui.DisplayDesiredQuantityRequest();
            userInput = ui.GetUserStorePurchaseInput();
            userInputQuantity = ui.ConvertStringToNumber(userInput, userInputQuantity);
            doesPlayerHaveEnoughMoney = ValidatePriceToPlayerMoney(player, userInputQuantity, ice.purchasePrice);
            if (doesPlayerHaveEnoughMoney)
            {
                for (int i = 1; i <= userInputQuantity; i++)
                {
                    player.money -= ice.purchasePrice;
                    player.inventory.ice.Add(new Ice());
                    player.inventory.ice.Add(new Ice());
                    player.inventory.ice.Add(new Ice());
                    player.inventory.ice.Add(new Ice());
                    player.inventory.ice.Add(new Ice());
                }
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.ReadKey();
            }
        }        
        public void SellCups(Player player, UI ui)
        {
            ui.DisplayDesiredQuantityRequest();
            userInput = ui.GetUserStorePurchaseInput();
            userInputQuantity = ui.ConvertStringToNumber(userInput, userInputQuantity);
            doesPlayerHaveEnoughMoney = ValidatePriceToPlayerMoney(player, userInputQuantity, cups.purchasePrice);
            if (doesPlayerHaveEnoughMoney)
            {
                for (int i = 1; i <= userInputQuantity; i++)
                {
                    player.money -= cups.purchasePrice;
                    player.inventory.cups.Add(new Cup());
                }
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.ReadKey();
            }
        }
        private bool ValidatePriceToPlayerMoney(Player player, int userQuantity, int purchasePrice)
        {
            doesPlayerHaveEnoughMoney = false;
            if ((userQuantity * purchasePrice) > player.money)
            {
                return doesPlayerHaveEnoughMoney;
            }
            doesPlayerHaveEnoughMoney = true;
            return doesPlayerHaveEnoughMoney; 
        }

    }
}
