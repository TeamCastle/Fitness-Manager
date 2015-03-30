namespace Fitness.Data.Repositories.UsersRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;

    using Fitness.Models;

    /// <summary>
    /// The 'ConcreteHandler' class. Gets the collection of users from database
    /// </summary>
    public class UsersFromDbRepository : AbstractUsersRepository
    {
        /// <summary>
        /// Path to Database file that contains the users
        /// </summary>
        private const string DbFilePath = "../../../Fitnessf.Data/Database/Users/users.mdb";

        /// <summary>
        /// Connection string used to open the database
        /// </summary>
        private const string DbConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" + DbFilePath;

        /// <summary>
        /// Reads a users from external database repository
        /// </summary>
        /// <returns>Returns a list of collection of users</returns>
        public override IList<User> ReadUsers()
        {
            if (!File.Exists(DbFilePath))
            {
                return this.Successor.ReadUsers();
            }

            var usersCollection = new List<User>();

            string selectString = "SELECT Users FROM English";

            using (var connection = new OleDbConnection(DbConnectionString))
            {
                connection.Open();
                var oldDbCommand = new OleDbCommand(selectString, connection);
                oldDbCommand.ExecuteNonQuery();

                using (var dataReader = oldDbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        usersCollection.Add(new User(null, null));
                    }
                }
            }

            return usersCollection;
        }
    }
}