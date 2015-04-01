namespace Fitness.Models.Exercises
{
    public class UpperBodyExercise : Exercise
    {
        public UpperBodyExercise(string description, MuscleGroup muscleGroup)
            : base(description, ExerciseType.UpperBody, muscleGroup)
        {
        }
    }
}
