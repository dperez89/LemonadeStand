using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class PointOfSale
    {
        //variables
        int saleSuccessThreshold = 80;
        int successfulSales;
        bool wasSaleSuccessful;

        public PointOfSale()
        {

        }

        //methods
        public void RunBusinessDay(Day day, string currentDayWeather, List<Customer> customers, Player player, UI ui)
        {

            for (int i = 0; i <= customers.Count; i++)
            {
                wasSaleSuccessful = false;
                wasSaleSuccessful = DetermineSaleSuccessOrFailure(i, day, currentDayWeather, customers, player, ui);
                if (wasSaleSuccessful == true)
                {
                    successfulSales++;
                    IncreasePlayerMoney(player);
                    if(successfulSales >= player.recipe.amountOfCupsInPitcher)
                    {
                        DecreasePlayerLemons(player);
                        DecreasePlayerSugars(player);
                        DecreasePlayerIce(player);
                        DecreasePlayerCups(player);
                    }
                }
            }
                
        }
        public bool DetermineSaleSuccessOrFailure(int i, Day day, string currentDayWeather, List<Customer> customers, Player player, UI ui)
        {
            if (customers.ElementAt(i).willingnessToBuy >= ((day.weather.temperature * day.weather.temperatureMod) + player.recipe.RecipeGrade));
            {
                wasSaleSuccessful = true;
            }
            return wasSaleSuccessful;  
        }
        private void IncreasePlayerMoney(Player player)
        {
            player.money += player.recipe.LemonadePrice;
        }
        private void DecreasePlayerLemons(Player player)
        {
            for(int i = 1; i <= player.recipe.Lemons; i++)
            {
                player.inventory.lemons.RemoveAt(0);
            }
        }
        private void DecreasePlayerSugars(Player player)
        {
            for(int i = 1; i <= player.recipe.Sugars; i++)
            {
                player.inventory.sugars.RemoveAt(0);
            }
        }
        private void DecreasePlayerIce(Player player)
        {
            for(int i = 1; i <= player.recipe.Ice; i++)
            {
                player.inventory.ice.RemoveAt(0);
            }
        }
        private void DecreasePlayerCups(Player player)
        {
            for(int i = 1; i <= player.recipe.amountOfCupsInPitcher; i++)
            {
                player.inventory.cups.RemoveAt(0);
            }
        }
    }
}
