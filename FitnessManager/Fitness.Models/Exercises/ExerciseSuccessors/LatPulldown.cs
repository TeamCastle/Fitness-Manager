namespace Fitness.Models.Exercises.ExerciseSuccessors
{
    using System;

    public class LatPulldown : Exercise
    {
        public LatPulldown(int numSet, int repeatCount)
            : base(numSet, repeatCount)
        {
            this.Description = string.Format(@"Sit down at a lat pulldown station and grab the bar 
                                                with an overhand grip that's just beyond shoulder width. Without moving your torso, pull your shoulders
                                                back and down, and bring the bar down to your chest. Pause, then slowly return to the starting position.
                                                Do {0} sets with {1} repeats with 70% of the weight you can lift.", this.NumberOfSet, this.RepeatCount);
        }
    }
}
