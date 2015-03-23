using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Users
{
    internal abstract class User
    {
        private string username;

        private string password;

        private string avatarPath;

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
            }
        }

        protected string Password { set; private get;}

        public string AvatarPath { set; get;}

        private User()
        { 
        
        }


    }
}
