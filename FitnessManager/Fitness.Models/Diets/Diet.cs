namespace Fitness.Models.Diets
{
    using System;

    using Fitness.Models.Interfaces;

    public abstract class Diet : IDiet
    {
        private double kilos;
        private double heightInCentimeters;
        private int age;

        /// <summary>
        /// To delete duration
        /// To delete motion
        /// </summary>
        public int duration = 10;

        private double motion;

        public Diet(double kilos1, double height1, int age1, Sex sex1)
        {
            this.Kilos = kilos1;
            this.HeightInCentimeters = height1;
            this.Age = age1;
            this.Sex = sex1;
        }

        public Diet(double kilos1, double height1, int age1, Sex sex1, int differenceInWeight)
        {
            this.Kilos = kilos1;
            this.HeightInCentimeters = height1;
            this.Age = age1;
            this.Sex = sex1;
        }

        protected double Kilos
        {
            get
            {
                return this.kilos;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Kilos should be a positive number");
                }

                this.kilos = value;
            }
        }

        protected double HeightInCentimeters
        {
            get
            {
                return this.heightInCentimeters;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height should be a positive number");
                }

                this.heightInCentimeters = value;
            }
        }

        protected int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age should be a positive number");
                }

                this.age = value;
            }
        }

        protected double Motion { get; set; }

        protected Sex Sex { get; set; }

        protected virtual TypeDiet TypeOfDiet { get; set; }

        public virtual double ShowDietCalculation()
        {
            double firstStepCalculation = 0;
            if (this.Sex == Sex.Male)
            {
                firstStepCalculation = (66 + 13.7 * this.Kilos + 5 * this.HeightInCentimeters - 6.8 * this.Age) * 1.2 - 200;
            }
            else
            {
                firstStepCalculation = (66 + 9.6 * this.Kilos + 1.8 * this.HeightInCentimeters - 4.7 * this.Age) * 1.2 - 100;
            }

            return firstStepCalculation;
        }
    }
}
