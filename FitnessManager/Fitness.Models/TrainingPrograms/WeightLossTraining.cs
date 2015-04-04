namespace Fitness.Models.TrainingPrograms
{
    using System;

    public class WeightLossTraining : TrainingProgram
    {
        // TODO: This class must be implemented
        public WeightLossTraining(string name, Intensity intensity)
            : base(name, intensity)
        {
        }

        public override string ShowCurrentDayExercises()
        {
            var currentDay = DateTime.Now;
            string currentDayProgram = string.Empty;

            switch (currentDay.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    break;
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Saturday:
                    break;
                case DayOfWeek.Sunday:
                    break;
                case DayOfWeek.Thursday:
                    break;
                case DayOfWeek.Tuesday:
                    break;
                case DayOfWeek.Wednesday:
                    break;
                default:
                    break;
            }

            return currentDayProgram;
        }
    }
}
