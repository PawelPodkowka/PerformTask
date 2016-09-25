using System;
using System.Runtime.Serialization;

namespace PerformTask.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class GraphValidationException : ValidationException
    {
        public GraphValidationException(string message) : base(message)
        {
        }

        public GraphValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GraphValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
