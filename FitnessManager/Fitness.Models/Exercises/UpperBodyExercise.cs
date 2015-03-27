namespace Fitness.Models.Exercises
{
    public class UpperBodyExercise : Exercise
    {
        const ExerciseType Type = ExerciseType.UpperBody;

        public UpperBodyExercise(string description, MuscleGroup muscleGroup)
            :base(description, UpperBodyExercise.Type, muscleGroup)
        {

        }
    }
}
