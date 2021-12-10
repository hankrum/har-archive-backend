using Microsoft.AspNetCore.Http;
using System;

namespace Har.Archive.Backend.Api.MiddleWare.ExceptionHandling
{
    public class ExceptionOptions
    {
        public Action<HttpContext, Exception, ErrorDescription> OverrideResponseDetails { get; set; }
    }
}
