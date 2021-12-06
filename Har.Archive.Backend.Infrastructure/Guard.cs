using System;

namespace Har.Archive.Backend.Infrastructure
{
    public static class Guard
    {
        private const string ValueCannotBeEmptyErrorMessage = "Value cannot be null or empty.";

        public static void ArgumentNotNull<TArgument>(TArgument value, string argumentName)
        {
            if (value is null)
            {
                throw new ArgumentNullException(argumentName ?? typeof(TArgument).Name);
            }
        }

        public static TArgument GetNotNullArgument<TArgument>(TArgument value, string argumentName)
            where TArgument : class
        {
            return value ?? throw new ArgumentNullException(argumentName ?? typeof(TArgument).Name);
        }

        public static void ArgumentNotNullOrWhiteSpace(string value, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ValueCannotBeEmptyErrorMessage, argumentName);
            }
        }
    }
}
