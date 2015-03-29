namespace Fitness.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Fitness.Engine;
    using Fitness.Models;

    public class FitnessManager
    {
        private static string username;
        private static string password;

        public static void Main()
        {
            // Temporary users
            UserManager.Users = new Dictionary<User, bool>();
            UserManager.Users.Add(new User("Ivan", "12345", Sex.Male, 25, 178, 75), false);
            UserManager.Users.Add(new User("Maria", "67890", Sex.Female, 22, 172, 55), false);

            while (true)
            {
                try
                {
                    Console.Write("Press [R] to Register, [L] to Login, [Q] to Logout or [S] to go... ");
                    var key = Console.ReadKey();
                    if (key.Key != ConsoleKey.L && key.Key != ConsoleKey.R && key.Key != ConsoleKey.Q && key.Key != ConsoleKey.S)
                    {
                        throw new Exception("\nWrong input!");
                    }

                    switch (key.Key)
                    {
                        // Register
                        case ConsoleKey.R:
                            Console.Write("\nUsername: ");
                            username = Console.ReadLine();
                            Console.Write("Password: ");
                            password = Console.ReadLine();
                            Console.Write("Press [M] for Male or [F] for Female: ");
                            var sexKey = Console.ReadKey();
                            if (sexKey.Key != ConsoleKey.M && sexKey.Key != ConsoleKey.F)
                            {
                                throw new Exception("\nWrong input!");
                            }
                            var sex = Sex.Male;
                            switch (sexKey.Key)
                            {
                                case ConsoleKey.M:
                                    sex = Sex.Male; break;
                                case ConsoleKey.F:
                                    sex = Sex.Female; break;
                                default: break;
                            }
                            Console.Write("\nAge: ");
                            var age = int.Parse(Console.ReadLine());
                            Console.Write("Height, [cm]: ");
                            var height = int.Parse(Console.ReadLine());   // in cm
                            Console.Write("Weight, [kg]: ");
                            var weight = int.Parse(Console.ReadLine());   // in kg
                            UserManager.Register(new User(username, password, sex, age, height, weight));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registered");
                            break;

                        // Login
                        case ConsoleKey.L:
                            Console.Write("\nUsername: ");
                            username = Console.ReadLine();
                            Console.Write("Password: ");
                            password = Console.ReadLine();
                            UserManager.Login(username, password);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged in");
                            break;

                        // Logout
                        case ConsoleKey.Q:
                            Console.Write("\nUsername: ");
                            username = Console.ReadLine();
                            UserManager.Logout(username);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged out");
                            break;

                        // Start the app
                        case ConsoleKey.S:

                            // TODO: Get the diet and training program
                            throw new NotImplementedException("\nNot Implemented!");

                            break;

                        default:
                            break;
                    }

                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }
    }
}
