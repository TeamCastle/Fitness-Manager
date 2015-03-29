namespace Fitness.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fitness.Models;

    public static class UserManager
    {
        /// <summary>
        /// Collection from Users and their login states ('true' for logged)
        /// </summary>
        public static Dictionary<User, bool> Users;

        /// <summary>
        /// Creates a registration of some new user.
        /// </summary>
        /// <param name="user">The new user.</param>
        public static void Register(User user)
        {
            if (Users.Any(u => u.Key.Username == user.Username))
            {
                throw new Exception("Such username is already used!");
            }

            Users.Add(user, false);
        }

        /// <summary>
        /// Login ...
        /// </summary>
        /// <param name="user">The user.</param>
        public static void Login(string username, string password)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                var currentUser = Users.ElementAt(i).Key;
                if (currentUser.Username == username)
                {
                    if (Users.ElementAt(i).Value)
                    {
                        throw new Exception("This user is already logged in!");
                    }

                    if (currentUser.Password == password)
                    {
                        Users[currentUser] = true;
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
        public static void Logout(string username)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                var currentUser = Users.ElementAt(i).Key;
                if (currentUser.Username == username)
                {
                    if (!Users.ElementAt(i).Value)
                    {
                        throw new Exception("This user is already logged out!");
                    }

                    Users[currentUser] = false;
                    return;
                }
            }

            throw new MissingMemberException("This user is not logged!");
        }
    }
}
