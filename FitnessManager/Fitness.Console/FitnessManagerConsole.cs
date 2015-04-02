namespace Fitness.Console
{
    using System;
    using System.Linq;
    using Fitness.Engine;
    using Fitness.Models;
    using Fitness.Models.UserRegimens;
    using Fitness.Engine.Factories;
    using Fitness.Models.TrainingPrograms;

    public class FitnessManagerConsole : FitnessManager
    {
        private User currentUser;
        private RegimenFactory regFactory;
        private TrainingFactory trainFactory;
        private DietFactory dietFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessManagerConsole"/> class.
        /// </summary>
        /// <param name="userManager">An instance of UserManager class.</param>
        public FitnessManagerConsole(UserManager userManager, ConsoleRenderer renderer)
            : base(userManager, renderer)
        {
            this.currentUser = null;
            this.dietFactory = new DietFactory();
        }

        public override void Start()
        {
            while (true)
            {
                try
                {
                    if (currentUser == null)
                    {
                        HandleUserLoginRegister();
                    }
                    else
                    {
                        if (currentUser.Regimen == null)
                        {
                            HandleUserRegimen();
                            HandleUserTrainingProgram();
                            HandleUserDiet();
                        }
                        else
                        {
                            //TODO: Do something with regimen:
                            //1. calculate diet
                            //2. get exercices for current day
                        }
                        
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

        private void HandleUserDiet()
        {
            if (this.dietFactory == null)
            {
                this.dietFactory = new DietFactory();
            }

            string currentRegimen = this.currentUser.Regimen.GetType().Name;            
            this.currentUser.Regimen.Diet = this.dietFactory
                .CreateDiet(currentRegimen, this.currentUser.Weight, this.currentUser.Height, this.currentUser.Age, this.currentUser.Sex);
            this.Renderer.RenderMessage(Messages.SuccessfulDietSetMessage);
            this.dietFactory = null;
        }

        private void HandleUserTrainingProgram()
        {
            //Lazy loading
            if (this.trainFactory == null)
            {
                this.trainFactory = new TrainingFactory();
            }

            string currentRegimen = this.currentUser.Regimen.GetType().Name;
            this.Renderer.RenderMessage(Messages.ChooseIntensityMessage);
            int intensityChoose = int.Parse(Console.ReadLine());
            Intensity intensity;
            switch (intensityChoose)
            {
                case 3: intensity = Intensity.ThreeDays; break;
                case 4: intensity = Intensity.FourDays; break;
                case 5: intensity = Intensity.FiveDays; break;
                case 6: intensity = Intensity.SixDays; break;
                default: throw new ArgumentException("Invalid intensity value");
            }

            this.currentUser.Regimen.Program = trainFactory.CreateTrainingProgram("Unknown", intensity, currentRegimen);
            this.Renderer.RenderMessage(Messages.SuccessfulTrainingSetMessage);
            this.trainFactory = null;
        }

        private void HandleUserRegimen()
        {
            if (this.currentUser.Regimen == null)
            {
                HandleUserRegimenCreation();
            }
        }

        private void HandleUserRegimenCreation()
        {
            //Lazy loading
            if (this.regFactory == null)
            {
                this.regFactory = new RegimenFactory();
            }

            this.Renderer.RenderMessage(Messages.ChooseRegimenMessage);
            this.Renderer.RenderMessage(Messages.RegimenCreationHelpMessage);
            string input = Console.ReadLine().ToUpper();
            var currentRegimen = regFactory.CreateRegimen(input);
            this.currentUser.Regimen = currentRegimen;

            this.regFactory = null;
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