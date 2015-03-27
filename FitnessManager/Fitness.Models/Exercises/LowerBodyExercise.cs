namespace Fitness.Models.Exercises
{
    public class LowerBodyExercise : Exercise
    {
        const ExerciseType Type = ExerciseType.LowerBody;

        public LowerBodyExercise(string description, MuscleGroup muscleGroup)
            : base(description, LowerBodyExercise.Type, muscleGroup)
        {

        }
    }
}
