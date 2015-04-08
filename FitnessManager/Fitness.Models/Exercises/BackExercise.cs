namespace Fitness.Models.Exercises.ExerciseSuccessors
{
    using Fitness.Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public static class BackExercise
    {
        private static ICollection<IExercise> rookieBackExercises;

        private static ICollection<IExercise> strenghtBackExercises;

        private static ICollection<IExercise> weghtLossBackExercises;

        public static IEnumerable<IExercise> GetRookieBackExercises()
        {
            rookieBackExercises = new List<IExercise>();

            rookieBackExercises.Add(new SeatedCableRow(2, 10));
            rookieBackExercises.Add(new BackExtensions(3, 8));
            rookieBackExercises.Add(new LatPulldown(3, 12));
            rookieBackExercises.Add(new DumbleRomanianDeadlift(3, 12));

            return rookieBackExercises;
        }

        public static ICollection<IExercise> GetStrenghtBackExercise()
        {
            strenghtBackExercises = new List<IExercise>();

            strenghtBackExercises.Add(new WeightedPullup(3, 6));
            strenghtBackExercises.Add(new Deadlift(3, 8));
            strenghtBackExercises.Add(new LatPulldown(3, 12));
            strenghtBackExercises.Add(new SeatedCableRow(3, 8));
            strenghtBackExercises.Add(new LandmineOneArmRow(3, 6));

            return strenghtBackExercises;
        }

        public static ICollection<IExercise> GetWeightLossBackExercise()
        {
            weghtLossBackExercises = new List<IExercise>();

            weghtLossBackExercises.Add(new LatPulldown(4, 12));
            weghtLossBackExercises.Add(new SeatedCableRow(4, 12));
            weghtLossBackExercises.Add(new DumbleRomanianDeadlift(4, 10));
            weghtLossBackExercises.Add(new BackExtensions(3, 15));
            weghtLossBackExercises.Add(new LandmineOneArmRow(2, 8));

            return weghtLossBackExercises;
        }

    }
}
