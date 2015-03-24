using Fitness.Models.TrainingPrograms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models.Interfaces
{
    public interface ITrainingFactory
    {
        ITrainingProgram CreateTrainingProgram(string name, Intensity intensity);
    }
}
