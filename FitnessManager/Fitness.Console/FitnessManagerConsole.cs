namespace Fitness.Console
{
    using Fitness.Data.Interfaces;
    using Fitness.Engine;

    public class FitnessManagerConsole : FitnessManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessManagerConsole"/> class.
        /// </summary>
        /// <param name="usersRepository">Collection of users.</param>
        public FitnessManagerConsole(UserManager userManager)
            : base(userManager)
        {
        }
    }
}