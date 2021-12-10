using Har.Archive.Backend.Api.MiddleWare.Models;
using System;
using System.Runtime.Serialization;

namespace Har.Archive.Backend.Api.MiddleWare.ExceptionHandling.Exceptions
{
    [Serializable]
    public class FluentValidationException : Exception
    {
        public ValidationResponseModel ValidationResponse { get; }

        public FluentValidationException(ValidationResponseModel validationResponse)
        {
            ValidationResponse = validationResponse;
        }

        public FluentValidationException()
        {
        }

        public FluentValidationException(string message)
            : base(message)
        {
        }

        public FluentValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected FluentValidationException(
            SerializationInfo serializationInfo,
            StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
