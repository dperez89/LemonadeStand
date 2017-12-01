using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        private int amountOfCupsInPitcher = 9;
        private int recipeGrade;
        private int lemonsQuality;
        private int sugarsQuality;
        private int iceQuality;
        private int lemonadePrice = 1;
        private int maximumLemonsThresholdThatWillIncreaseQuality = 8;
        private int maximumSugarsThresholdThatWillIncreaseQuality = 7;
        private int maximumIceThresholdThatWillIncreaseQuality = 10;
        private int lemonsQualityModifier = 3;
        private int sugarsQualityModifier = 3;
        private int iceQualityModifier = 3;
        private int lemons = 4;
        private int sugars = 4;
        private int ice = 4;                
        public int Lemons
        {
            get
            {
                return lemons;
            }
            set
            {
                lemons = value;
            }
        }

        public int Sugars
        {
            get
            {
                return sugars;
            }
            set
            {
                sugars = value;
            }
        }

        public int Ice
        {
            get
            {
                return ice;
            }
            set
            {
                ice = value;
            }
        }
        public int RecipeGrade
        {
            get
            {
                return recipeGrade;
            }
            set
            {
                recipeGrade = value;
            }
        }
        public int LemonadePrice
        {
            get
            {
                return lemonadePrice;
            }
            set
            {
                lemonadePrice = value;
            }
        }
        public int AmountOfCupsInPitcher
        {
            get
            {
                return amountOfCupsInPitcher;
            }
        }



        public Recipe()
        {

        }

        //methods
        public void SetRecipeGrade()
        {
            lemonsQuality = ResolveQuaityFromLemons(lemons);
            sugarsQuality = ResolveQuaityFromSugars(sugars);
            iceQuality = ResolveQuaityFromIce(ice);
            recipeGrade = lemonsQuality + sugarsQuality + iceQuality;

        }
        private int ResolveQuaityFromLemons(int lemons)
        {
            if(lemons <= maximumLemonsThresholdThatWillIncreaseQuality)
            {
                lemonsQuality = lemons * lemonsQualityModifier;
                return lemonsQuality;
            }
            else
            {
                lemonsQuality = (maximumLemonsThresholdThatWillIncreaseQuality * lemonsQualityModifier) - ((lemons - maximumLemonsThresholdThatWillIncreaseQuality) * lemonsQualityModifier);
                return lemonsQuality;
            }
        }
        private int ResolveQuaityFromSugars(int sugars)
        {
            if (sugars <= maximumSugarsThresholdThatWillIncreaseQuality)
            {
                sugarsQuality = sugars * sugarsQualityModifier;
                return sugarsQuality;
            }
            else
            {
                sugarsQuality = (maximumSugarsThresholdThatWillIncreaseQuality * sugarsQualityModifier) - ((sugars - maximumSugarsThresholdThatWillIncreaseQuality) * sugarsQualityModifier);
                return sugarsQuality;
            }
        }
        private int ResolveQuaityFromIce(int ice)
        {
            if (ice <= maximumIceThresholdThatWillIncreaseQuality)
            {
                iceQuality = ice * iceQualityModifier;
                return iceQuality;
            }
            else
            {
                iceQuality = (maximumIceThresholdThatWillIncreaseQuality * iceQualityModifier) - ((ice - maximumIceThresholdThatWillIncreaseQuality) * iceQualityModifier);
                return iceQuality;
            }
        }
    }
}
