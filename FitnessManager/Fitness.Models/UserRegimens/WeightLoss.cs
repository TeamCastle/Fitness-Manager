namespace Fitness.Models.UserRegimens
{
    using Fitness.Models.Interfaces;

    /// <summary>
    /// User regimen for person who wants to lose weight 
    /// </summary>
    public class WeightLoss : Regimen
    {
        public WeightLoss(string name, ITrainingProgram trainingProgram, IDiet diet, int duration)
            : base(name, trainingProgram, diet, duration)
        {
        }
    }
}
