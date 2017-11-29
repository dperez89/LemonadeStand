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
        private int userQuantity;
        bool doesPlayerHaveEnoughMoney;

        public Store()
        {
            lemons = new Lemon();
            ice = new Ice();
            sugars = new Sugar();
            cups = new Cup();
        }

        public void SellLemons(Player player, UI ui)
        {
            ui.DisplayDesiredQuantityRequest();
            userInput = ui.GetUserStorePurchaseInput();
            userQuantity = ui.ConvertStringToNumber(userInput, userQuantity);
            doesPlayerHaveEnoughMoney = ValidatePriceToPlayerMoney(player, userQuantity, lemons.purchasePrice);
            if(doesPlayerHaveEnoughMoney)
            {
                for (int i = 1; i <= userQuantity; i++)
                {
                    player.money -= lemons.purchasePrice;
                    player.inventory.lemons.Add(new Lemon());
                }
            }
            else
            {
                Console.WriteLine("Not enough money!");
                SellLemons(player, ui);
            }
        }
        public void SellIce(Player player, UI ui)
        {
            ui.DisplayDesiredQuantityRequest();
            userInput = ui.GetUserStorePurchaseInput();
            userQuantity = ui.ConvertStringToNumber(userInput, userQuantity);
            doesPlayerHaveEnoughMoney = ValidatePriceToPlayerMoney(player, userQuantity, ice.purchasePrice);
            if (doesPlayerHaveEnoughMoney)
            {
                for (int i = 1; i <= userQuantity; i++)
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
                SellIce(player, ui);
            }
        }
        public void SellSugar(Player player, UI ui)
        {
            ui.DisplayDesiredQuantityRequest();
            userInput = ui.GetUserStorePurchaseInput();
            userQuantity = ui.ConvertStringToNumber(userInput, userQuantity);
            doesPlayerHaveEnoughMoney = ValidatePriceToPlayerMoney(player, userQuantity, sugars.purchasePrice);
            if (doesPlayerHaveEnoughMoney)
            {
                for (int i = 1; i <= userQuantity; i++)
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
                SellSugar(player, ui);
            }
        }
        public void SellCups(Player player, UI ui)
        {
            ui.DisplayDesiredQuantityRequest();
            userInput = ui.GetUserStorePurchaseInput();
            userQuantity = ui.ConvertStringToNumber(userInput, userQuantity);
            doesPlayerHaveEnoughMoney = ValidatePriceToPlayerMoney(player, userQuantity, cups.purchasePrice);
            if (doesPlayerHaveEnoughMoney)
            {
                for (int i = 1; i <= userQuantity; i++)
                {
                    player.money -= cups.purchasePrice;
                    player.inventory.cups.Add(new Cup());
                }
            }
            else
            {
                Console.WriteLine("Not enough money!");
                SellCups(player, ui);
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
