namespace Fitness.Models.Interfaces
{
    /// <summary>
    /// This interface must be implemented by all kind of users
    /// </summary>
    public interface IUser
    {
        string Username { get; set; }

        string Password { get; set; }

        IRegimen Regimen { get; set; }
    }
}
