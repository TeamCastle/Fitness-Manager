namespace Fitness.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fitness.Data.Access;
    using Fitness.Models;

    public class UserManager
    {
        /// <summary>
        /// Collection from Users and their login states ('true' for logged)
        /// </summary>
        private Dictionary<User, bool> users;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        public UserManager()
        {
            this.GetDbUsers();
        }

        /// <summary>
        /// Creates a registration of some new user.
        /// </summary>
        /// <param name="user">The new user.</param>
        public void Register(User user)
        {
            if (this.users.Any(u => u.Key.Username == user.Username))
            {
                throw new Exception("Such username is already used!");
            }

            this.users.Add(user, false);
        }

        /// <summary>
        /// Login ...
        /// </summary>
        /// <param name="user">The user.</param>
        public void Login(string username, string password)
        {
            for (int i = 0; i < this.users.Count; i++)
            {
                var currentUser = this.users.ElementAt(i).Key;
                if (currentUser.Username == username)
                {
                    if (this.users.ElementAt(i).Value)
                    {
                        throw new Exception("This user is already logged in!");
                    }

                    if (currentUser.Password == password)
                    {
                        this.users[currentUser] = true;
                        return;
                    }

                    throw new Exception("Wrong password!");
                }
            }

            throw new MissingMemberException("This user is not registered!");
        }

        /// <summary>
        /// Logout ...
        /// </summary>
        /// <param name="user">The user.</param>
        public void Logout(string username)
        {
            for (int i = 0; i < this.users.Count; i++)
            {
                var currentUser = this.users.ElementAt(i).Key;
                if (currentUser.Username == username)
                {
                    if (!this.users.ElementAt(i).Value)
                    {
                        throw new Exception("This user is already logged out!");
                    }

                    this.users[currentUser] = false;
                    return;
                }
            }

            throw new MissingMemberException("This user is not logged!");
        }

        private void GetDbUsers()
        {
            this.users = new Dictionary<User, bool>();
            var data = DbAccess.GetData(@"..\..\..\Fitness.Data\Database\Users.mdb", "SELECT * FROM Users");
            foreach (var user in data)
            {
                var username = user[1].ToString();
                var password = user[2].ToString();
                var sex = user[3].ToString() == "male" ? Sex.Male : Sex.Female;
                var age = int.Parse(user[4].ToString());
                var height = int.Parse(user[4].ToString());
                var weight = int.Parse(user[5].ToString());

                this.users.Add(new User(username, password, sex, age, height, weight), false);
            }
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
