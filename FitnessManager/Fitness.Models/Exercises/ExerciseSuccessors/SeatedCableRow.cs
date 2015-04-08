namespace Fitness.Models.Exercises.ExerciseSuccessors
{
    using System;

    public class SeatedCableRow : Exercise
    {
        public SeatedCableRow(int numSet, int repeatCount)
            : base(numSet, repeatCount)
        {
            this.Description = string.Format(@"Attach a straight or lat-pulldown bar to the pulley of a
                                                seated row station. Sit on the bench (or floor) with your feet
                                                against the foot plate and knees slightly bent. Keeping your lower
                                                back flat, bend forward at the hips to grasp the bar and row it to your
                                                sternum, squeezing your shoulder blades together in the end position.
                                                Extend your arms and feel the stretch in your backbefore beginning the next rep.
                                                You have to do {0} sets with {1} repeats. Use 60% of the weight you can lift.", this.NumberOfSet, this.RepeatCount);
        }
    }
}
