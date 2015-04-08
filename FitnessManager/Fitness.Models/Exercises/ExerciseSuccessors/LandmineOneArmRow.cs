namespace Fitness.Models.Exercises.ExerciseSuccessors
{
    using System;

    public class LandmineOneArmRow : Exercise
    {
        public LandmineOneArmRow(int numSet, int repeatCount)
            : base(numSet, repeatCount)
        {
            this.Description = string.Format(@"Place the end of the bar into a corner. Wrap towels around it put padding the
                                                corner to avoid damage. Facing away from the corner, hold the barbell at the top, behind where you load the weights, with your
                                                right hand. Stand so your left leg is forward and keeping your lower back flat, bend at the hips until your torso is about parallel
                                                to the floor. Draw your shoulder blade back and row the bar to your ribs. Number of sets: {0} with {1} repeats.", this.NumberOfSet, this.RepeatCount);
        }
    }
}
