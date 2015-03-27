namespace Fitness.Engine.Factories
{
    using System;

    using Fitness.Models.Interfaces;
    using Fitness.Models.TrainingPrograms;

    public class TrainingFactory : ITrainingFactory
    {
        public ITrainingProgram CreateTrainingProgram(string name, Intensity intensity, ProgramType programType)
        {
            if (programType == ProgramType.Rookie)
            {
                return new RookieTraining(name, intensity);
            }
            else if (programType == ProgramType.Strength)
            {
                return new StrengthTraining(name, intensity);
            }
            else if (programType == ProgramType.WeightLoss)
            {
                return new WeightLossTraining(name, intensity);
            }
            else
            {
                throw new InvalidProgramException(programType.ToString());
            }
        }
    }
}
