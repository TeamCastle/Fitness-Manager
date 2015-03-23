namespace Fitness.Models.UserRegimen
{
    using Fitness.Models.Interfaces;
    
    /// <summary>
    /// An abstract class for User regimen extensions
    /// </summary>
    public abstract class Regimen : IRegimen
    {
        public Regimen(string name, ITrainingProgram trainingProgram, IDiet diet)
        {
            this.Name = name;
            this.Program = trainingProgram;
            this.Diet = diet;
        }

        public string Name { get; set; }

        public ITrainingProgram Program { get; set; }

        public IDiet Diet { get; set; }      
    }
}
