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
        public List<User> Users { get; private set; }

        /// <summary>
        /// Creates a registration of some new user.
        /// </summary>
        /// <param name="user">The new user.</param>
        public void Register(User user)
        {
            if (this.Users.Any(u => u.Username == user.Username))
            {
                throw new Exception("Such username is already used!");
            }

            this.Users.Add(user);
        }

        /// <summary>
        /// Login the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public User Login(string username, string password)
        {
            var loginUser = this.Users.Where(x => x.Username == username).FirstOrDefault(y => y.Password == password);
            if (loginUser != null)
            {
                return loginUser;
            }
            else
            {
                throw new ArgumentException("Invalid username or password!");
            }
            
        }

        /// <summary>
        /// Logout the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Logout(string username)
        {
            var currentUser = this.Users.FirstOrDefault(x => x.Username == username);
            if (currentUser != null)
            {             
                return;
            }

            throw new MissingMemberException("This user is not logged!");
                       
        }

        public Regimen GetUserRegimen(string username)
        {
            var currentUser = this.Users.FirstOrDefault(x => x.Username == username);
            if (currentUser != null)
            {
                return currentUser.Regimen as Regimen;
            }

            return null;
        }

        private void GetUsers(IUsersRepository usersRepository)
        {
            this.Users = new List<User>();
            usersRepository.Users.ToList().ForEach(user => this.Users.Add(user));
        }
    }
}
