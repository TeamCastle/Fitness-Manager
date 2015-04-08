namespace Fitness.Models.Interfaces
{
    using Fitness.Models.Exercises;
    using System.Collections;

    public interface IExercise
    {
        string Description { get; set; }

        int NumberOfSet { get; set; }

        int RepeatCount { get; set; }

    }
}
