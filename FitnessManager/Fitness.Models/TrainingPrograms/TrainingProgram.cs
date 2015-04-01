namespace Fitness.Models.TrainingPrograms
{
    using System;

    using Fitness.Models.Interfaces;

    public abstract class TrainingProgram : ITrainingProgram
    {
        // TODO: This class must be implemented
        public TrainingProgram(string name, Intensity intensity)
        {
            this.Name = name;   
            this.Intensity = intensity;
        }

        public string Name { get; set; }

        public Intensity Intensity { get; set; }

        public void ShowCurrentDayExercises(TrainingDay day)
        {
            throw new NotImplementedException();
        }
    }
}
