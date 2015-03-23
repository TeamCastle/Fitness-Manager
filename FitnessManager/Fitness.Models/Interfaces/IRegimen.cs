namespace Fitness.Models.Interfaces
{
    public class IRegimen
    {
        string Name { get; set; }

        ITrainingProgram Program { get; set; }

        IDiet Diet { get; set; }  
    }
}
