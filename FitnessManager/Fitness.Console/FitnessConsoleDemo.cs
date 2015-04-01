namespace Fitness.Console
{
    using Fitness.Data.Repositories.UsersRepositories;
    using Fitness.Engine;

    /// <summary>
    /// Class containing a program that starts the Fitness Manager for console.
    /// </summary>
    public class FitnessConsoleDemo
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        public static void Main()
        {
            var usersFromDb = new UsersFromDbRepository();
            var usersFromExcel = new UsersFromExcelRepository();
            var usersFromStaticList = new UsersFromStaticListRepository();

            var usersFromRepository = new UsersFromRepository(usersFromDb, usersFromExcel, usersFromStaticList);

            var userManager = new UserManager(usersFromRepository);

            FitnessManager fitnessManager = new FitnessManagerConsole(userManager);
            fitnessManager.Start();
        }
    }
}