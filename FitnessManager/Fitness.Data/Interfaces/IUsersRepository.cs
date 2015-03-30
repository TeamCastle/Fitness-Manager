namespace Fitness.Data.Interfaces
{
    using System.Collections.Generic;

    using Fitness.Models;

    public interface IUsersRepository
    {
        IList<User> Users { get; set; }

        IList<User> ReadUsers();
    }
}