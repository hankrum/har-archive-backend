using Har.Archive.Backend.Api.MiddleWare.ExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Http;
using System;

namespace Har.Archive.Backend.Api.MiddleWare.ExceptionHandling
{
    public static class ExceptionHandlingExtensions
    {
        public static void ConfigureExceptionHandling(ExceptionOptions exceptionOptions)
        {
            exceptionOptions.OverrideResponseDetails = (context, exception, errorDescription) =>
            {
                errorDescription.StatusCode = BuildResponseStatusCodeForException(exception);
                errorDescription.Details = exception.Message;
                context.Response.StatusCode = errorDescription.StatusCode;
            };
        }

        private static short BuildResponseStatusCodeForException(Exception exception)
        {
            return exception switch
            {
                EntityNotFoundException _ => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
        }
    }
}
