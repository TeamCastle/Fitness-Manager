namespace Fitness.Models.Exercises
{
    public class Exercise
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
