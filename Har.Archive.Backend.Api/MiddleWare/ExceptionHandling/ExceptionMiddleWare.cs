using Har.Archive.Backend.Api.MiddleWare.ExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Har.Archive.Backend.Api.MiddleWare.ExceptionHandling
{
    public class ExceptionMiddleWare
    {
        public class ExceptionMiddleware
        {
            private readonly RequestDelegate _next;

            private readonly ExceptionOptions _options;

            // TODO: Logging
            public ExceptionMiddleware(ExceptionOptions options, RequestDelegate next)
            {
                _next = next;
                _options = options;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (FluentValidationException validationException)
                {
                    await HandleValidationException(context, validationException);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex, _options);
                }
            }

            private async Task HandleValidationException(HttpContext context, FluentValidationException exception)
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(exception.ValidationResponse));
            }

            private Task HandleExceptionAsync(HttpContext context, Exception exception, ExceptionOptions opts)
            {
                var error = new ErrorDescription
                {
                    Id = Guid.NewGuid().ToString(),
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Title = "An error occurred in the API.  Please use the id and contact support team if the problem persists.",
                };

                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                opts.OverrideResponseDetails?.Invoke(context, exception, error);

                var errorResponse = JsonConvert.SerializeObject(error);

                return context.Response.WriteAsync(errorResponse);
            }
        }
    }
}
