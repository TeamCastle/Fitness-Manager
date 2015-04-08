namespace Fitness.Models.Exercises.ExerciseSuccessors
{
    using System;

    public class DumbleRomanianDeadlift : Exercise
    {
        public DumbleRomanianDeadlift(int numSet, int repeatCount)
            : base(numSet, repeatCount)
        {
            this.Description = string.Format(@"Grasp two dumbbells and hold them with feet hip width apart. Keeping your lower back in its natural arch
                                                bend hips back, your torso forward, and lower yourself until you feel a stretch in your hamstrings.
                                                You may bend at the knees. Squeeze your glutes at
                                                the top of the movement after coming back up.
                                                Do {0} sets with {1} repeats. Use minimum 10kg. dumbells.", this.NumberOfSet, this.RepeatCount);
        }
    }
}
