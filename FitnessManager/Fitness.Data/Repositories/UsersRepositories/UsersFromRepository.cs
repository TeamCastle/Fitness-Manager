namespace Fitness.Data.Repositories.UsersRepositories
{
    using System;
    using System.Collections.Generic;

    using Fitness.Models;

    /// <summary>
    /// Implements AbstractUsersRepository class and sets all user repositories
    /// </summary>
    public class UsersFromRepository : AbstractUsersRepository
    {
        /// <summary>
        /// Users from database repository
        /// </summary>
        private UsersFromDbRepository usersFromDb;

        /// <summary>
        /// Users from file repository
        /// </summary>
        private UsersFromExcelRepository usersFromExcel;

        /// <summary>
        /// Users from static list repository
        /// </summary>
        private UsersFromStaticListRepository usersFromStaticList;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersFromRepository"/> class.
        /// </summary>
        /// <param name="usersFromDb">Users from database repository</param>
        /// <param name="usersFromExcel">Users from file repository</param>
        /// <param name="usersFromStaticList">Users from static list repository</param>
        public UsersFromRepository(UsersFromDbRepository usersFromDb, UsersFromExcelRepository usersFromExcel, UsersFromStaticListRepository usersFromStaticList)
        {
            this.usersFromDb = usersFromDb;
            this.usersFromExcel = usersFromExcel;
            this.usersFromStaticList = usersFromStaticList;
            this.Users = this.ReadUsers();
        }

        /// <summary>
        /// Reads a list of users from some repository
        /// </summary>
        /// <returns>Returns a collection of users</returns>
        public override IList<User> ReadUsers()
        {
            this.usersFromDb.SetSuccessor(this.usersFromExcel);
            this.usersFromExcel.SetSuccessor(this.usersFromStaticList);

            return this.usersFromDb.ReadUsers();
        }
    }
}