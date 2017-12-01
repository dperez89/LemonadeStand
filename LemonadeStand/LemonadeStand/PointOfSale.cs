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
        private int successfulSales;
        private int cupsOfLemonade;
        private int amountMadeInSalesToday;
        bool soldOut = false;

        public int SuccessfulSales
        {
            get
            {
                return successfulSales;
            }
            set
            {
                successfulSales = value;
            }
        }
        public int CupsOfLemonade
        {
            get
            {
                return cupsOfLemonade;
            }
            set
            {
                cupsOfLemonade = value;
            }
        }
        public int AmountMadeInSalesToday
        {
            get
            {
                return amountMadeInSalesToday;
            }
            set
            {
                amountMadeInSalesToday = value;
            }
        }

        public PointOfSale()
        {

        }

        //methods
        public void RunBusinessDay(Day day, string currentDayWeather, List<Customer> customers, Player player, UI ui)
        {
            soldOut = false;
            AmountMadeInSalesToday = 0;
            CupsOfLemonade = 0;
            for (int i = 0; i <= customers.Count; i++)
            {
                if (soldOut)
                {
                    continue;
                }
                
                bool wasSaleSuccessful = DetermineSaleSuccessOrFailure(i, day, currentDayWeather, customers, player, ui);
                if (wasSaleSuccessful == true)
                {
                    if(CupsOfLemonade > 0 && player.inventory.cups.Count > 0)
                    {
                        SuccessfulSales++;
                        IncreasePlayerMoney(player);
                        IncreaseAmountMadeInSalesToday(player);
                        DecreasePlayerCups(player);
                        CupsOfLemonade--;
                    }
                    else
                    {
                        try
                        {
                            DecreasePlayerLemons(player);
                            DecreasePlayerSugars(player);
                            DecreasePlayerIce(player);
                            CupsOfLemonade = player.recipe.AmountOfCupsInPitcher;
                            DecreasePlayerCups(player);
                            SuccessfulSales++;
                            IncreasePlayerMoney(player);
                            IncreaseAmountMadeInSalesToday(player);

                        }
                        catch
                        {
                            soldOut = true;
                        }
                       
                    }
                }
            }
                
        }
        public bool DetermineSaleSuccessOrFailure(int i, Day day, string currentDayWeather, List<Customer> customers, Player player, UI ui)
        {
            bool wasSaleSuccessful;
            if (customers.ElementAt(i).willingnessToBuy >= ((day.weather.temperature * day.weather.temperatureMod) + player.recipe.RecipeGrade))
            {
               wasSaleSuccessful = true;
            }
            else
            {
                wasSaleSuccessful = false;
            }
            return wasSaleSuccessful;  
        }
        private void IncreasePlayerMoney(Player player)
        {
            player.Money += player.recipe.LemonadePrice;
            player.TotalMoneyEarned += player.recipe.LemonadePrice;
        }
        private void IncreaseAmountMadeInSalesToday(Player player)
        {
            AmountMadeInSalesToday += player.recipe.LemonadePrice;
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
            player.inventory.cups.RemoveAt(0);
        }
    }
}
