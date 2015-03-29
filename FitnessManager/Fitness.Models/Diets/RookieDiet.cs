namespace Fitness.Models.Diets
{
    public class RookieDiet : Diet
    {
        public RookieDiet(double kilos1, double height1, int age1, Sex sex1)
            :base(kilos1,height1,age1,sex1)
       {
           this.Kilos = kilos1;
           this.HeightInCentimeters = height1;
           this.Age = age1;
           this.Sex = sex1;
       }

        public override double CaloriesCalculation()
        {
            double firstStepCalculation = 0;
            if (this.Sex == Sex.Male)
            {
                firstStepCalculation = (66 + 13.7 * this.Kilos + 5 * this.HeightInCentimeters - 6.8 * this.Age) * this.Motion - 200;
            }
            else
            {
                firstStepCalculation = (66 + 9.6 * this.Kilos + 1.8 * this.HeightInCentimeters - 4.7 * this.Age) * 1.2 - 100;
            }
            return firstStepCalculation;

        }
        public override TypeDiet TypeOfDiet 
        {
            get
            {
                return TypeDiet.RookieDiet;
            }
        }

       
    }
}
