using System;
namespace Fitness.Models.Diets
{
    public class WeightLossDiet : Diet
    {
        private int weightMinus;
        public WeightLossDiet (double kilos1, double height1, int age1, Sex sex1, int differenceInWeight1)
            :base(kilos1,height1,age1,sex1,differenceInWeight1)
        {
           this.Kilos = kilos1;
           this.HeightInCentimeters = height1;
           this.Age = age1;
           this.Sex = sex1;
           this.WeightMinus = differenceInWeight1;
        }
        public override TypeDiet TypeOfDiet
        {
            get
            {
                return TypeDiet.WeightDiet;
            }
        }
       
        public int WeightMinus
        {
            get
            {
                return this.weightMinus;
            }
            set
            {
                if (value <= 0 || value >= this.Kilos)
                {
                    throw new ArgumentException("This type of diet requerse weight-minus to be  a negative number");
                }
                this.weightMinus = value;
            }
        }
        public override double CaloriesCalculation()
        {
            double firstStepCalculation = 0;
            if (this.Sex == Sex.Male)
            {
                firstStepCalculation = (66 + 13.7 * this.Kilos + 5 * this.HeightInCentimeters - 6.8 * this.Age)* this.Motion - this.WeightMinus / this.duration * 1000;
            }
            else
            {
                firstStepCalculation = (66 + 9.6 * this.Kilos + 1.8 * this.HeightInCentimeters - 4.7 * this.Age)*this.Motion - this.WeightMinus / this.duration*1000;
            }
            return firstStepCalculation;

        }
    }
}
