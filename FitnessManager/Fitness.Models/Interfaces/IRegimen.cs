namespace Fitness.Models.Interfaces
{
    /// <summary>
    /// This interface must be implemented by all kind of regimens
    /// </summary>
    public interface IRegimen
    {
        string Name { get; set; }

        ITrainingProgram Program { get; set; }

        IDiet Diet { get; set; }  
    }
}
