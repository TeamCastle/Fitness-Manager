namespace Fitness.Models.Exercises.ExerciseSuccessors
{
    using System;

    public class Deadlift : Exercise
    {
        public Deadlift(int numSet, int repeatCount)
            : base(numSet, repeatCount)
        {
            this.Description = string.Format(@"Stand with feet hip width apart and bend hips back.
                                                Your grip should be just outside of knees. Keeping a flat black, extend your hips to stand up, and
                                                pull the bar up to lock out. While pulling, keep your eyes on the ground a few feet in front of you.
                                                Lock out is with hips drive through and shoulders back. Lower bar back to start.
                                                Number of sets: {0} with {1} repeats. Maximum weight usage please!", this.NumberOfSet, this.RepeatCount);
        }
    }
}
