namespace Fitness.Models.Exercises
{
    using Fitness.Models.Interfaces;
    using System;

    public abstract class Exercise : IExercise
    {
        private int repeatCount;

        private int numberOfSet;

        public Exercise(int numSet,int repeatCount)
        {
            this.NumberOfSet = numSet;
            this.RepeatCount = repeatCount;
        }

        public string Description { get; set; }

        public int RepeatCount
        {
            get { return this.repeatCount; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid value for RepeatCount.");
                }

                this.repeatCount = value;
            }
        }


        public int NumberOfSet
        {
             get { return this.numberOfSet; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid value for NumberOfSet.");
                }

                this.numberOfSet = value;
            }
        }
    }

}
