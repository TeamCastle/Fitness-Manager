namespace Fitness.Engine
{
    using System;
    using System.Collections.Generic;

    using Fitness.Models;
    using Fitness.Models.UserRegimens;

    /// <summary>
    /// Main abstract class of the Fitness Manager.
    /// </summary>
    public abstract class FitnessManager
    {
        private static string username;

        private static string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessManager"/> class.
        /// </summary>
        /// <param name="userManager">An instance of the class UserManager.</param>
        public FitnessManager(UserManager userManager)
        {
            this.UserManager = userManager;
            this.Users = userManager.Users;
        }

        public UserManager UserManager { get; set; }

        /// <summary>
        /// Collection from Users and their login states.
        /// </summary>
        protected IDictionary<User, bool> Users { get; set; }

        /// <summary>
        /// Runs the application.
        /// </summary>
        public void Start()
        {
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
                                    sex = Sex.Male;
                                    break;
                                case ConsoleKey.F:
                                    sex = Sex.Female;
                                    break;
                                default:
                                    break;
                            }

                            Console.Write("\nAge: ");
                            var age = int.Parse(Console.ReadLine());
                            Console.Write("Height, [cm]: ");
                            var height = int.Parse(Console.ReadLine());   // in cm
                            Console.Write("Weight, [kg]: ");
                            var weight = int.Parse(Console.ReadLine());   // in kg
                            this.UserManager.Register(new User(username, password, sex, age, height, weight));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registered");
                            break;

                        // Login
                        case ConsoleKey.L:
                            Console.Write("\nUsername: ");
                            username = Console.ReadLine();
                            Console.Write("Password: ");
                            password = Console.ReadLine();
                            this.UserManager.Login(username, password);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged in");
                            break;

                        // Logout
                        case ConsoleKey.Q:
                            Console.Write("\nUsername: ");
                            username = Console.ReadLine();
                            this.UserManager.Logout(username);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Logged out");
                            break;

                        // Start the app
                        case ConsoleKey.S:
                            // TODO: Get the diet and training program
                            throw new NotImplementedException("\nNot Implemented!");
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

        /// <summary>
        /// Export the regimen to two PDF files.
        /// </summary>
        /// <param name="regimen">The regimen.</param>
        public void ExportRegimenToPdf(Regimen regimen)
        {
            // var diet = regimen.Diet;

            // var dataTable = new DataTable("Diet");
            // dataTable.Columns.Add(new DataColumn("ColumnHeader1", typeof(Int32)));
            // dataTable.Columns.Add(new DataColumn("ColumnHeader2", typeof(string)));
            // DataRow dataRow;
            // int rows = 5;
            // for (int i = 0; i < rows; i++)
            // {
            //     dataRow = dataTable.NewRow();
            //     dataRow["ColumnHeader1"] = null;    // 1st column content 
            //     dataRow["ColumnHeader2"] = null;    // 2nd column content
            //     dataTable.Rows.Add(dataRow);
            // }

            // dataTable.AcceptChanges();

            // FileAccess.WritePdf("Diet", dataTable, @"..\..\..\..\Diet.pdf");
        }
    }
}
