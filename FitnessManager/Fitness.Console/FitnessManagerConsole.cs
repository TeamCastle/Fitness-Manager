namespace Fitness.Console
{
    using System;
    using System.Linq;
    using Fitness.Engine;
    using Fitness.Models;
    using Fitness.Models.UserRegimens;

    public class FitnessManagerConsole : FitnessManager
    {
        private User currentUser;
        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessManagerConsole"/> class.
        /// </summary>
        /// <param name="userManager">An instance of UserManager class.</param>
        public FitnessManagerConsole(UserManager userManager, ConsoleRenderer renderer)
            : base(userManager, renderer)
        {
            this.currentUser = null;
        }

        public override void Start()
        {
            bool isLogged = false;
            while (true)
            {
                try
                {
                    if (isLogged != true)
                    {
                        HandleUserLoginRegister();
                        isLogged = true;
                    }
                    else
                    {
                        HandleUserRegimen();
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }

        private void HandleUserRegimen()
        {
            if (this.currentUser.Regimen != null)
            {
                
            }
            else
            {
                HandleUserRegimenCreation();
            }
        }

        private void HandleUserRegimenCreation()
        {
            this.Renderer.RenderMessage(Messages.ChooseRegimenMessage);
            this.Renderer.RenderMessage(Messages.RegimenCreationHelpMessage);
            string input = Console.ReadLine().ToUpper();
            switch(input)
            {
               //TODO: Must be implemented!
                default:
                    break;
            }
        }

        private void HandleUserLoginRegister()
        {
            this.Renderer.RenderMessage(Messages.WelcomeMessage);
            this.Renderer.RenderMessage(Messages.IntroMessage);

            var key = Console.ReadLine().ToUpper();
            if (key != "L" && key != "R")
            {
                throw new Exception("\nWrong input!");
            }

            switch (key)
            {
                case "R":
                    HandleUserRegistrationThroughConsole();
                    break;
                case "L":
                    HandleLoginThroughConsole();
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }

        private void HandleLogoutThroughConsole()
        {
            this.Renderer.RenderMessage(Messages.EnterUsernameMessage);
            string username = Console.ReadLine();
            this.currentUser = null;
            base.HandleLogout(username);
        }

        private void HandleLoginThroughConsole()
        {
            this.Renderer.RenderMessage(Messages.EnterUsernameMessage);
            string username = Console.ReadLine();
            this.Renderer.RenderMessage(Messages.EnterPasswordMessage);
            string password = Console.ReadLine();
            base.HandleLogin(username, password);
        }

        private void HandleUserRegistrationThroughConsole()
        {
            this.Renderer.RenderMessage(Messages.EnterUsernameMessage);
            string username = Console.ReadLine();
            this.Renderer.RenderMessage(Messages.EnterPasswordMessage);
            string password = Console.ReadLine();
            this.Renderer.RenderMessage(Messages.EnterGenderMessage);
            string genderString = Console.ReadLine();
            Sex gender;
            if (genderString.ToLower() == "f")
            {
                gender = Sex.Female;
            }
            else
            {
                gender = Sex.Male;
            }

            this.Renderer.RenderMessage(Messages.AgeMessage);
            int age = int.Parse(Console.ReadLine());
            this.Renderer.RenderMessage(Messages.HeightMessage);
            int height = int.Parse(Console.ReadLine());
            this.Renderer.RenderMessage(Messages.WeightMessage);
            int weight = int.Parse(Console.ReadLine());
            User newUser = new User(username, password, gender, age, height, weight);
            this.currentUser = newUser;
            base.HandleUserRegistration(newUser);
        }
    }
}