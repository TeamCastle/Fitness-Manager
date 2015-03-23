namespace Fitness.Models
{
    using System;
    using System.Text.RegularExpressions;

    using Fitness.Models.Interfaces;

    public class User : IUser
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.UserRegimen = null;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (Regex.IsMatch(value, "[a-zA-Z0-9]"))
                {
                    this.username = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Username!");
                }
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            } 
            set
            {
                this.password = value;
            }
        }

        public IRegimen UserRegimen { get; set; }

        public string AvatarPath { get; set; }
    }
}
