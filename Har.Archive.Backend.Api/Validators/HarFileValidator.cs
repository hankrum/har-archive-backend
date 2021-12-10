using FluentValidation;
using Har.Archive.Backend.Data.Services.DtoModels;

namespace Har.Archive.Backend.Api.Validators
{
    public class HarFileValidator : AbstractValidator<HarFile>
    {
        public HarFileValidator()
        {
            RuleFor(harfile => harfile.Name).NotEmpty().NotNull();
            RuleFor(harfile => harfile.Path).NotNull();
        }
    }
}
