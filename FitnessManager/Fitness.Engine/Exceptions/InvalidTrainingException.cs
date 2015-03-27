namespace Fitness.Engine.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidTrainingException : Exception
    {
        public InvalidTrainingException()
            : base()
        {
        }

        public InvalidTrainingException(string message)
            :base(string.Format("Invalid training type {0}", message))
        {
            
        }

        public InvalidTrainingException(string message, Exception inner)
            : base(string.Format("Invalid training type {0}", message), inner)
        {
        }
    }
}
