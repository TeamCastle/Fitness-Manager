namespace Fitness.Models.Diets
{
    using System;

    public class StrengthDiet : Diet
    {
        private int weightPlus;

        public StrengthDiet(double kilos1, double height1, int age1, Sex sex1, int differenceInWeight1)
            : base(kilos1, height1, age1, sex1, differenceInWeight1)
        {
            this.WeightPlus = differenceInWeight1;
        }

        protected virtual TypeDiet typeOfDiet { get; private set; }

        protected override TypeDiet TypeOfDiet
        {
            get
            {
                return TypeDiet.StrengthDiet;
            }
        }

        private int WeightPlus
        {
            get
            {
                return this.weightPlus;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("This type of diet requerse weight-plus to be  a positive number");
                }

                this.weightPlus = value;
            }
        }

        public override double ShowDietCalculation()
        {
            double firstStepCalculation = 0;
            if (this.Sex == Sex.Male)
            {
                firstStepCalculation = (66 + 13.7 * this.Kilos + 5 * this.HeightInCentimeters - 6.8 * this.Age) * 1.2 + (this.WeightPlus / this.duration) * 100;
            }
            else
            {
                firstStepCalculation = (66 + 9.6 * this.Kilos + 1.8 * this.HeightInCentimeters - 4.7 * this.Age) * 1.2 + (this.weightPlus / this.duration) * 100;
            }

            return firstStepCalculation;
        }
    }
}
