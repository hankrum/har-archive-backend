using System.Collections.Generic;

namespace Har.Archive.Backend.Api.MiddleWare.Models
{
    public class ValidationResponseModel
    {
        public ValidationResponseModel(int status, string title, List<ValidationErrorModel> errors)
        {
            Status = status;
            Title = title;
            Errors = errors;
        }

        public int Status { get; }

        public string Title { get; }

        public List<ValidationErrorModel> Errors { get; }
    }
}
