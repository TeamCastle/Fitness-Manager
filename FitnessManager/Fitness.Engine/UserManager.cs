namespace Fitness.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fitness.Data.Interfaces;
    using Fitness.Data.Repositories.UsersRepositories;
    using Fitness.Models;

    public class UserManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        public UserManager(IUsersRepository usersRepository)
        {
            this.GetUsers(usersRepository);
        }

        /// <summary>
        /// Collection from Users and their login states ('true' for logged).
        /// </summary>
        public Dictionary<User, bool> Users { get; private set; }

        /// <summary>
        /// Creates a registration of some new user.
        /// </summary>
        /// <param name="user">The new user.</param>
        public void Register(User user)
        {
            if (this.Users.Any(u => u.Key.Username == user.Username))
            {
                throw new Exception("Such username is already used!");
            }

            this.Users.Add(user, false);
        }

        /// <summary>
        /// Login ...
        /// </summary>
        /// <param name="user">The user.</param>
        public void Login(string username, string password)
        {
            for (int i = 0; i < this.Users.Count; i++)
            {
                var currentUser = this.Users.ElementAt(i).Key;
                if (currentUser.Username == username)
                {
                    if (this.Users.ElementAt(i).Value)
                    {
                        throw new Exception("This user is already logged in!");
                    }

                    if (currentUser.Password == password)
                    {
                        this.Users[currentUser] = true;
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
            for (int i = 0; i < this.Users.Count; i++)
            {
                var currentUser = this.Users.ElementAt(i).Key;
                if (currentUser.Username == username)
                {
                    if (!this.Users.ElementAt(i).Value)
                    {
                        throw new Exception("This user is already logged out!");
                    }

                    this.Users[currentUser] = false;
                    return;
                }
            }

            throw new MissingMemberException("This user is not logged!");
        }

        private void GetUsers(IUsersRepository usersRepository)
        {
            this.Users = new Dictionary<User, bool>();
            usersRepository.Users.ToList().ForEach(user => this.Users.Add(user, false));
        }
    }
}
