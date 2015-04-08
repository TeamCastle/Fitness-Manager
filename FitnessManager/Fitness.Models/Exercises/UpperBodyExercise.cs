namespace Fitness.Models.Exercises
{
    using Fitness.Models.Interfaces;
    using Fitness.Models.Exercises;
    using System.Collections;
    using System.Collections.Generic;
    using Fitness.Models.Exercises.ExerciseSuccessors;

    public static class UpperBodyExercise
    {
        public static  ICollection<IExercise> RookieUpperBodyTrainingExercises()
        {
            List<IExercise> collectionOfExercises = new List<IExercise>();

            collectionOfExercises.AddRange(BackExercise.GetRookieBackExercises());

            // TODO: Add collections for Biceps, Triceps, Traps, Arms Exercises;

            return collectionOfExercises;
        }

        public static ICollection<IExercise> StrenghtUpperBodyTrainingExercises()
        {
            List<IExercise> collectionOfExercises = new List<IExercise>();

            collectionOfExercises.AddRange(BackExercise.GetStrenghtBackExercise());

            // TODO: Add collections for Biceps, Triceps, Traps, Arms Exercises;

            return collectionOfExercises;
        }

        public static ICollection<IExercise> WeightLossUpperBodyTrainingExercises()
        {
            List<IExercise> collectionOfExercises = new List<IExercise>();

            collectionOfExercises.AddRange(BackExercise.GetWeightLossBackExercise());

            // TODO: Add collections for Biceps, Triceps, Traps, Arms Exercises;

            return collectionOfExercises;
        }
    }
}
