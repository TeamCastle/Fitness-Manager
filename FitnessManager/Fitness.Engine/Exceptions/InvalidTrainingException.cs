namespace Fitness.Engine.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidTrainingException : Exception
    {
        private const string InvalidStringFormat = "Invalid training type {0}";

        public InvalidTrainingException()
            : base()
        {
        }

        public InvalidTrainingException(string message)
            : base(string.Format(InvalidStringFormat, message))
        {
        }

        public InvalidTrainingException(string message, Exception inner)
            : base(string.Format(InvalidStringFormat, message), inner)
        {
        }
    }
}
