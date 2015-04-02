namespace Fitness.Models.Interfaces
{
    using Fitness.Models.TrainingPrograms;

    public interface ITrainingFactory
    {
        ITrainingProgram CreateTrainingProgram(string name, Intensity intensity,string progType);
    }
}
