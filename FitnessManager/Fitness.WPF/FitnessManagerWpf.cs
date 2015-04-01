namespace Fitness.WPF
{
    using Fitness.Engine;

    class FitnessManagerWpf : FitnessManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessManagerWpf"/> class.
        /// </summary>
        /// <param name="usersRepository">Collection of users.</param>
        public FitnessManagerWpf(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
