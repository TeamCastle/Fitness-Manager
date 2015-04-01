namespace Fitness.Data.Repositories.UsersRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;

    using Fitness.Models;
    using Fitness.Data.Access;

    /// <summary>
    /// The 'ConcreteHandler' class. Gets the collection of users from database
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
            var data = DbAccess.GetData(DbFilePath, QueryString);
            foreach (var user in data)
            {
                var username = user[1].ToString();
                var password = user[2].ToString();
                var sex = user[3].ToString() == "male" ? Sex.Male : Sex.Female;
                var age = int.Parse(user[4].ToString());
                var height = int.Parse(user[4].ToString());
                var weight = int.Parse(user[5].ToString());

                usersCollection.Add(new User(username, password, sex, age, height, weight));
            }

            return usersCollection;
        }

        private void DbUpdate()
        {
            // TODO:

            // Get some data from DB
            // var data = DbAccess.GetData(@"..\..\..\Fitness.Data\Database\Users.mdb", "SELECT * FROM Users WHERE username='admin' AND password='admin'");

            // Insert, delete or update some data in DB
            // DbAccess.ManipulateData(@"..\..\..\Fitness.Data\Database\Users.mdb", "INSERT INTO Users values(22,'katya','12345')");        
        }
    }
}