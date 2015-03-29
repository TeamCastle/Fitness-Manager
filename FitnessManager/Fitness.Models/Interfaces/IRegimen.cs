namespace Fitness.Models.Interfaces
{
    using System;

    /// <summary>
    /// This interface must be implemented by all kind of regimens
    /// </summary>
    public interface IRegimen
    {
        string Name { get; set; }

        DateTime Date { get; }

        ITrainingProgram Program { get; set; }

        IDiet Diet { get; set; }

        int Duration { get; set; }
    }
}
