namespace Fitness.Console
{
    using Fitness.Engine;

    public class FitnessManagerConsole : FitnessManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessManagerConsole"/> class.
        /// </summary>
        /// <param name="userManager">An instance of UserManager class.</param>
        public FitnessManagerConsole(UserManager userManager, ConsoleRenderer renderer)
            : base(userManager, renderer)
        {
        }
    }
}