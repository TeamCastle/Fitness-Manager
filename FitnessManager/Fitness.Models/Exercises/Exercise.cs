namespace Fitness.Models.Exercises
{
    using Fitness.Models.Interfaces;

    public abstract class Exercise : IExercise
    {
        public Exercise(string description, ExerciseType type, MuscleGroup muscleGroup)
        {
            this.Description = description;
            this.ExerciseType = type;
            this.MuscleGroup = muscleGroup;
        }

        public string Description { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public MuscleGroup MuscleGroup { get; set; }
    }
}
