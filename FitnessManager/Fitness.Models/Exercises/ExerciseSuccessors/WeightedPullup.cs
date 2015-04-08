namespace Fitness.Models.Exercises.ExerciseSuccessors
{
    using System;

    public class WeightedPullup : Exercise
    {
        public WeightedPullup(int numSet, int repeatCount)
            : base(numSet, repeatCount)
        {
            this.Description = string.Format(@"Attach a weighted belt to your waist, hold a dumbbell between your feet,
                                                or if you can’t complete your reps with weight, use body weight alone. Hang from a pullup bar with hands
                                                just outside shoulder width. Pull yourself up until your chin is over the bar.
                                                Make {0} sets with {1} repeats and use maximum of the weight you can lift.", this.NumberOfSet, this.RepeatCount);
        }
    }
}
