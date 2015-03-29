namespace Fitness.Models.UserRegimens
{
    using System;

    using Fitness.Models.Interfaces;

    /// <summary>
    /// An abstract class for User regimen extensions
    /// </summary>
    public abstract class Regimen : IRegimen
    {
        public Regimen(string name, ITrainingProgram trainingProgram, IDiet diet, int duration)
        {
            this.Name = name;
            this.Program = trainingProgram;
            this.Diet = diet;
            this.Duration = duration;

            this.Date = DateTime.Now;
        }

        public string Name { get; set; }

        public DateTime Date { get; private set; }

        public ITrainingProgram Program { get; set; }

        public IDiet Diet { get; set; }

        public int Duration { get; set; }
    }
}
