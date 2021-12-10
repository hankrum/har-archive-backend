using System.Collections.Generic;

namespace Har.Archive.Backend.Api.MiddleWare.Models
{
    public class ValidationErrorModel
    {
        public ValidationErrorModel(
            string propertyName,
            string errorMessage,
            object attemptedValue,
            string errorCode,
            Dictionary<string, object> formattedMessagePlaceholderValues)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            AttemptedValue = attemptedValue;
            ErrorCode = errorCode;
            FormattedMessagePlaceholderValues = formattedMessagePlaceholderValues;
        }

        public string PropertyName { get; }

        public string ErrorMessage { get; }

        public object AttemptedValue { get; }

        public Dictionary<string, object> FormattedMessagePlaceholderValues { get; }

        public string ErrorCode { get; }
    }
}
