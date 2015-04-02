namespace Fitness.Models.Diets
{
    using System;

    public class WeightLossDiet : Diet
    {
        private int weightMinus;

        public WeightLossDiet(double kilos1, double height1, int age1, Sex sex1, int differenceInWeight1)
            : base(kilos1, height1, age1, sex1, differenceInWeight1)
        {
            this.WeightMinus = differenceInWeight1;
        }

        protected override TypeDiet TypeOfDiet
        {
            get
            {
                return TypeDiet.WeightDiet;
            }
        }

        private int WeightMinus
        {
            get
            {
                return this.weightMinus;
            }

            set
            {
                if (value >= 0 || value >= this.Kilos)
                {
                    throw new ArgumentException("This type of diet requerse weight-minus to be  a negative number");
                }

                this.weightMinus = value;
            }
        }

        public override double ShowDietCalculation()
        {
            double firstStepCalculation = 0;
            if (this.Sex == Sex.Male)
            {
                firstStepCalculation = (66 + 13.7 * this.Kilos + 5 * this.HeightInCentimeters - 6.8 * this.Age) * 1.2 + (this.WeightMinus / this.duration) * 100;
            }
            else
            {
                firstStepCalculation = (66 + 9.6 * this.Kilos + 1.8 * this.HeightInCentimeters - 4.7 * this.Age) * 1.2 + (this.weightMinus / this.duration) * 100;
            }

            return firstStepCalculation;
        }
    }
}
