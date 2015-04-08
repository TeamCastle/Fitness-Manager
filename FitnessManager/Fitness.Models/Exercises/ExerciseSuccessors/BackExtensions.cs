namespace Fitness.Models.Exercises.ExerciseSuccessors
{
    using System;

    public class BackExtensions : Exercise
    {
        public BackExtensions(int numSet, int repeatCount)
            : base(numSet, repeatCount)
        {
            this.Description = string.Format(@"Lock your legs into a back extension bench
                                                and allow your torso to bend forward so that
                                                your hips are bent almost 90 degrees. Extend your hips so that your
                                                body forms a straight line. You have to do {0} sets with {1} repeats.", this.NumberOfSet, this.RepeatCount);
        }
    }
}
