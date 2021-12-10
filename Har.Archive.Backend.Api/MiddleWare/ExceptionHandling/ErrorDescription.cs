using System.Collections.Generic;

namespace Har.Archive.Backend.Api.MiddleWare.ExceptionHandling
{
    public class ErrorDescription
    {
        public string Id { get; internal set; }

        public string Title { get; internal set; }

        public short StatusCode { get; set; }

        public string Details { get; set; }

        public string Links { get; set; }

        public ErrorSource Source { get; set; }

        public string ErrorCode { get; set; }

        public List<string> PropertyNames { get; set; } = new List<string>();
    }
}
