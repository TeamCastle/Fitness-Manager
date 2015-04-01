namespace Fitness.Data.Repositories.UsersRepositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Fitness.Models;

    /// <summary>
    /// The 'ConcreteHandler' class. Gets the collection of users from text file
    /// </summary>
    public class UsersFromExcelRepository : AbstractUsersRepository
    {
        /// <summary>
        /// Path to text file that contains the users
        /// </summary>
        private const string UsersFilePath = "../../../Fitness.Data/Database/Users/Users.xls";

        /// <summary>
        /// Reads a users from external file repository
        /// </summary>
        /// <returns>Returns a list of collection of users</returns>
        public override IList<User> ReadUsers()
        {
            if (!File.Exists(UsersFilePath))
            {
                return this.Successor.ReadUsers();
            }

            var usersCollection = new List<User>();

            using (var reader = new StreamReader(UsersFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var user = reader.ReadLine();

                    if (!string.IsNullOrEmpty(user))
                    {
                        usersCollection.Add(new User(null, null));
                    }
                }
            }

            return usersCollection;
        }
    }
}