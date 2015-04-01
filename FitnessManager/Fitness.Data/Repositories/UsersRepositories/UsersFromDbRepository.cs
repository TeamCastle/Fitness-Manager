namespace Fitness.Data.Repositories.UsersRepositories
{
    using System.Collections.Generic;

    using Fitness.Data.Access;
    using Fitness.Models;

    /// <summary>
    /// Gets the collection of users from database file.
    /// </summary>
    public class UsersFromDbRepository : AbstractUsersRepository
    {
        /// <summary>
        /// Path to Database file that contains the users.
        /// </summary>
        private const string DbFilePath = @"..\..\..\Fitness.Data\Database\users.mdb";

        /// <summary>
        /// Query string to select all users from the database file.
        /// </summary>
        private const string QueryString = "SELECT * FROM Users";

        /// <summary>
        /// Reads a users from external database repository.
        /// </summary>
        /// <returns>Returns a list of collection of users.</returns>
        public override IList<User> ReadUsers()
        {
            if (!System.IO.File.Exists(DbFilePath))
            {
                return this.Successor.ReadUsers();
            }

            var usersCollection = this.GetCollection(DbAccess.GetData(DbFilePath, QueryString));

            return usersCollection;
        }

        private void DbUpdate()
        {
            // TODO:

            // Get some data from DB
            // var data = DbAccess.GetData(@"..\..\..\Fitness.Data\Database\Users.mdb", "SELECT * FROM Users WHERE username='admin' AND password='admin'");

            // Insert, delete or update some data in DB
            // DbAccess.ManipulateData(@"..\..\..\Fitness.Data\Database\Users.mdb", "INSERT INTO Users values('katya','12345')");        
        }
    }
}