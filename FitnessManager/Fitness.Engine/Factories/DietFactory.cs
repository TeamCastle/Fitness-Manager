namespace Fitness.Engine.Factories
{
    using Fitness.Models;
    using Fitness.Models.Diets;
    using System;

    public class DietFactory
    {
        public Diet CreateDiet(string dietType, double kilos, double height, int age, Sex sex)
        {
            if (dietType == "Rookie")
            {
                return new RookieDiet(kilos, height, age, sex);
            }
            else if(dietType == "Strength")
            {
                return new StrengthDiet(kilos, height, age, sex, 0);
            }
            else if(dietType == "WeightLoss")
            {
                return new WeightLossDiet(kilos, height, age, sex, 0);
            }
            else
            {
                throw new ArgumentException("Invalid diet type");
            }
        }
    }
}
