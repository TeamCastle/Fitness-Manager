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
        
        public int duration;
        private double motion;

       public Diet(double kilos1,double height1,int age1, Sex sex1)
       {
           this.Kilos = kilos1;
           this.HeightInCentimeters = height1;
           this.Age = age1;
           this.Sex = sex1;
       }
       public Diet(double kilos1, double height1, int age1, Sex sex1,int differenceInWeight)
       {
           this.Kilos = kilos1;
           this.HeightInCentimeters = height1;
           this.Age = age1;
           this.Sex = sex1;
       }

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

    
        public double Motion { get; private set; }

        public Sex Sex { get;protected set; }

        public virtual TypeDiet TypeOfDiet { get; set; }

        public virtual double CaloriesCalculation()
        {
            double firstStepCalculation = 0;
            if (this.Sex == Sex.Male)
            {
                 firstStepCalculation = (66 + 13.7 * this.Kilos + 5 * this.HeightInCentimeters - 6.8 * this.Age)*this.Motion-200;
            }
            else
            {
                 firstStepCalculation = (66 + 9.6 * this.Kilos + 1.8 * this.HeightInCentimeters - 4.7 * this.Age)*this.Motion-100;
            }
            return firstStepCalculation;
           
        }

        public  void ShowDietCalculation()
        {
            Console.WriteLine("Still nothing");

        }
    }
}
