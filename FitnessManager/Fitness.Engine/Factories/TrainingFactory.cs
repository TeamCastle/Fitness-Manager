namespace Fitness.Engine.Factories
{
    using System;

    using Fitness.Models.Interfaces;
    using Fitness.Models.TrainingPrograms;

    public class TrainingFactory : ITrainingFactory
    {
        public ITrainingProgram CreateTrainingProgram(string name, Intensity intensity)
        {
            throw new NotImplementedException();
        }
    }
}
