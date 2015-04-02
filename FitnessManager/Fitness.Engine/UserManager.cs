namespace Fitness.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fitness.Data.Interfaces;
    using Fitness.Data.Repositories.UsersRepositories;
    using Fitness.Models;
using Fitness.Models.UserRegimens;

    public class UserManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        /// <param name="usersRepository">Some user repository.</param>
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
        /// Login the user.
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
        /// Logout the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Logout(string username)
        {
            var currentUser = this.Users.Keys.FirstOrDefault(x => x.Username == username);
            if (currentUser != null)
            {
                this.Users[currentUser] = false;
                return;
            }

            throw new MissingMemberException("This user is not logged!");
                       
        }

        public Regimen GetUserRegimen(string username)
        {
            var currentUser = this.Users.Keys.FirstOrDefault(x => x.Username == username);
            if (currentUser != null)
            {
                return currentUser.Regimen as Regimen;
            }

            return null;
        }

        private void GetUsers(IUsersRepository usersRepository)
        {
            this.Users = new Dictionary<User, bool>();
            usersRepository.Users.ToList().ForEach(user => this.Users.Add(user, false));
        }
    }
}
