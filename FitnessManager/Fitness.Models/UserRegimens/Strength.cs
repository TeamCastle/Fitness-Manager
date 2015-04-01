namespace Fitness.Models.UserRegimens
{
    using Fitness.Models.Interfaces;

    /// <summary>
    /// User regimen for person who is or wants to be a bodybuilder.
    /// </summary>
    public class Strength : Regimen
    {
        public Strength(string name, ITrainingProgram trainingProgram, IDiet diet, int duration)
            : base(name, trainingProgram, diet, duration)
        {
        }
    }
}
