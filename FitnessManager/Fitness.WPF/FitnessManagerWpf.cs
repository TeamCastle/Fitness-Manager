namespace Fitness.WPF
{
    using Fitness.Engine;

    public class FitnessManagerWpf : FitnessManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessManagerWpf"/> class.
        /// </summary>
        /// <param name="userManager">An instance of UserManager class.</param>
        public FitnessManagerWpf(UserManager userManager)
            : base(userManager, null)
        {
        }
    }
}
