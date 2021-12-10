using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Har.Archive.Backend.Api.MiddleWare.ExceptionHandling.Exceptions
{
    [Serializable]
    public abstract class DomainException : Exception
    {
        public abstract string ErrorCode { get; }

        public abstract List<string> PropertyNames { get; }

        public DomainException()
        {
        }

        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
