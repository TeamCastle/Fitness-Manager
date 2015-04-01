namespace Fitness.Data.Repositories.UsersRepositories
{
    using System.Collections.Generic;

    using Fitness.Data.Interfaces;
    using Fitness.Models;

    public abstract class AbstractUsersRepository : IUsersRepository
    {
        private HashSet<User> users = new HashSet<User>();

        public IList<User> Users
        {
            get
            {
                return new List<User>(this.users);
            }
            set
            {
                this.users = new HashSet<User>(value);
            }
        }

        /// <summary>
        /// Gets or sets the successor for some users repository class.
        /// </summary>
        protected AbstractUsersRepository Successor { get; set; }

        /// <summary>
        /// Sets a successor for some users repository class.
        /// </summary>
        /// <param name="successor">The successor.</param>
        public void SetSuccessor(AbstractUsersRepository successor)
        {
            this.Successor = successor;
        }

        /// <summary>
        /// Abstract method which reads a list of users from some repository.
        /// </summary>
        /// <returns>Returns a collection of users.</returns>
        public abstract IList<User> ReadUsers();
    }
}