namespace Fitness.Models.Interfaces
{
    using Fitness.Models.Exercises;

    public interface IExercise
    {
        string Description { get; set; }

        ExerciseType ExerciseType { get; set; }

        MuscleGroup MuscleGroup { get; set; }
    }
}
