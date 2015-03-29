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
        }

        public User(string username, string password, Sex sex, int age, int height, int weight)
            : this(username, password)
        {
            this.Sex = sex;
            this.Age = age;
            this.Height = height;
            this.Weight = weight;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (Regex.IsMatch(value, @"[a-zA-Z0-9]"))
                {
                    this.username = value;
                }

                throw new ArgumentException("Invalid Username!");
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
                if (value.Length >= 5 && value.Length <= 20)
                {
                    this.password = value;
                }

                throw new ArgumentException("Invalid Password!");
            }
        }

        public Sex Sex { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public IRegimen Regimen { get; set; }
    }
}
