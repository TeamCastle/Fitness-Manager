namespace Fitness.Data.Repositories.UsersRepositories
{
    using System.Collections;
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

        protected List<User> GetCollection(IEnumerable data)
        {
            var usersCollection = new List<User>();
            foreach (dynamic user in data)
            {
                var username = user[0].ToString();
                var password = user[1].ToString();
                var sex = user[2].ToString() == "male" ? Sex.Male : Sex.Female;
                var age = int.Parse(user[3].ToString());
                var height = int.Parse(user[4].ToString());
                var weight = int.Parse(user[5].ToString());

                usersCollection.Add(new User(username, password, sex, age, height, weight));
            }

            return usersCollection;
        }
    }
}