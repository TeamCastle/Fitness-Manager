using System;
namespace Fitness.Models.Diets
{
    public class StrengthDiet : Diet
    {
        private int weightPlus;

        public StrengthDiet(double kilos1, double height1, int age1, Sex sex1, int differenceInWeight1)
            :base(kilos1,height1,age1,sex1,differenceInWeight1)
        {
           this.Kilos = kilos1;
           this.HeightInCentimeters = height1;
           this.Age = age1;
           this.Sex = sex1;
           this.WeightPlus = differenceInWeight1;
        }
        protected virtual TypeDiet typeOfDiet { get; private set; }
        public int WeightPlus
        {
            get 
            {
                return this.weightPlus;
            }
            set 
            { 
                if(value<=0)
                {
                    throw new ArgumentException("This type of diet requerse weight-plus to be  a positive number");
                }
                this.weightPlus = value;
            }
        }
        public override TypeDiet TypeOfDiet
        {
            get
            {
                return TypeDiet.StrengthDiet;
            }
        }

        public override double CaloriesCalculation()
        {
            double firstStepCalculation = 0;
            if (this.Sex == Sex.Male)
            {
               firstStepCalculation = (66 + 13.7 * this.Kilos + 5 * this.HeightInCentimeters - 6.8 * this.Age)* 1.2 +(this.WeightPlus / this.duration) * 10000;
            }
            else
            {
                firstStepCalculation = (66 + 9.6 * this.Kilos + 1.8 * this.HeightInCentimeters - 4.7 * this.Age)* 1.2 + (this.WeightPlus / this.duration) * 10000;
            }
            return firstStepCalculation;

        }
    }
}
