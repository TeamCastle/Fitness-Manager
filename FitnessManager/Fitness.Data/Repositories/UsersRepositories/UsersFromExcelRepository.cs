namespace Fitness.Data.Repositories.UsersRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using Fitness.Data.Access;
    using Fitness.Models;

    /// <summary>
    /// Gets the collection of users from Excel file.
    /// </summary>
    public class UsersFromExcelRepository : AbstractUsersRepository
    {
        /// <summary>
        /// Path to the Excel file that contains the users.
        /// </summary>
        private const string ExcelFilePath = "../../../Fitness.Data/Database/users.xlsx";

        /// <summary>
        /// Reads a users from external Excel file repository.
        /// </summary>
        /// <returns>Returns a list of collection of users.</returns>
        public override IList<User> ReadUsers()
        {
            if (!System.IO.File.Exists(ExcelFilePath))
            {
                return this.Successor.ReadUsers();
            }

            var usersCollection = this.GetCollection(FileAccess.ReadExcel(ExcelFilePath).Rows);

            return usersCollection;
        }
    }
}