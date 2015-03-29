namespace Fitness.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Fitness.Models.Diets;

    public class FitnessManager
    {
        public static void Main()
        {

            RookieDiet vanq = new RookieDiet(56, 165, 19, Sex.Female);

            Console.WriteLine(vanq.CaloriesCalculation());

            StrengthDiet me = new StrengthDiet(56, 165, 19, Sex.Female, 25);
            Console.WriteLine(me.CaloriesCalculation());

            WeightLossDiet metoo=new WeightLossDiet(56,165,19,Sex.Female,-10);
            Console.WriteLine(metoo.CaloriesCalculation());
               
        }
    }
}
