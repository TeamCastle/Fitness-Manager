namespace Fitness.Engine.Factories
{
    using System;
    using Fitness.Models.Interfaces;
    using Fitness.Models.UserRegimens;

    public class RegimenFactory
    {
        public IRegimen CreateRegimen(string command)
        {
            if (command == "R")
            {
                return new Rookie("Rookie Regimen", null, null, 0);
            }
            else if(command == "S")
            {
                return new Strength("Strength Regimen", null, null, 0);
            }
            else if(command == "W")
            {
                return new WeightLoss("WeightLoss Regimen", null, null, 0);
            }
            else
            {
                throw new ArgumentException("Invalid command for Regimen");
            }
        }
    }
}
