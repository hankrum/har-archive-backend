using Microsoft.AspNetCore.Builder;
using System;
using static Har.Archive.Backend.Api.MiddleWare.ExceptionHandling.ExceptionMiddleWare;

namespace Har.Archive.Backend.Api.MiddleWare.ExceptionHandling
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandler(
            this IApplicationBuilder builder,
            Action<ExceptionOptions> configureOptions)
        {
            var options = new ExceptionOptions();
            configureOptions(options);

            return builder.UseMiddleware<ExceptionMiddleware>(options);
        }

        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
        {
            var options = new ExceptionOptions();
            return builder.UseMiddleware<ExceptionMiddleware>(options);
        }
    }
}
