namespace Fitness.Models.Diets
{
    using System;
    using Fitness.Models.Interfaces;

    public abstract class Diet : IDiet
    {
        private double kilos;
        private double heightInCentimeters;
        private int age;
        private TypeDiet typeOfDiet;
        private double motion;
        private Sex sex;

       

        public double Kilos
        {
            get 
            {
                return this.kilos;
            }

            protected set
            { 
                if(value<=0)
                {
                    throw new ArgumentOutOfRangeException("Kilos should be a positive number");
                }
                this.kilos = value;
            
            }
        
        }

        public double HeightInCentimeters
        {
            get 
            {
                return this.heightInCentimeters;
            }

            protected set
            { 
                if(value<=0)
                {
                    throw new ArgumentOutOfRangeException("Height should be a positive number");
                }
                this.heightInCentimeters = value;
            
            }
        
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age should be a positive number");
                }
                this.age = value;

            }

        }

        public TypeDiet TypeOfDiet{get;private set;}
        public double Motion { get; private set; }

        public Sex Sex { get;private set }

        public void ShowDietCalculation()
        {
            double firstStepCalculation = (66 + 13.7 * this.Kilos + 5 * this.HeightInCentimeters - 6.8 * this.Age);
           
        }
    }
}
