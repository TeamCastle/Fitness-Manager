namespace Fitness.Models.Interfaces
{
    public interface IUser
    {
        string Username { get; set; }

        string Password { get; set; }

        IRegimen UserRegimen { get; set; }
    }
}
