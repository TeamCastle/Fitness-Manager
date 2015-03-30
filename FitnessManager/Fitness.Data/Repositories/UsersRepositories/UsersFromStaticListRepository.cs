namespace Fitness.Data.Repositories.UsersRepositories
{
    using System.Collections.Generic;

    using Fitness.Models;

    /// <summary>
    /// The 'ConcreteHandler' class. Gets the collection of users from static collection.
    /// </summary>
    public class UsersFromStaticListRepository : AbstractUsersRepository
    {
        /// <summary>
        /// Collection of static users
        /// </summary>
        private readonly IList<User> staticListUsers = new List<User>()
        {
            new User(null, null),
            new User(null, null),
            new User(null, null)
        };

        /// <summary>
        /// Reads a users from static list repository
        /// </summary>
        /// <returns>Returns a list of collection of static users</returns>
        public override IList<User> ReadUsers()
        {
            return this.staticListUsers;
        }
    }
}