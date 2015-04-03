namespace Fitness.Models.TrainingPrograms
{
    using System;

    using Fitness.Models.Interfaces;
    using System.Collections.Generic;

    public abstract class TrainingProgram : ITrainingProgram
    {
        public TrainingProgram(string name, Intensity intensity)
        {
            this.Name = name;   
            this.Intensity = intensity;
        }

        public string Name { get; set; }

        public Intensity Intensity { get; set; }

        public IList<IExercise> Exercises { get; set; }

        public virtual string ShowCurrentDayExercises()
        {
            return null;
        }
    }
}