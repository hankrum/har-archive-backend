using AutoMapper;
using Domain = Har.Archive.Backend.Data.Domain;
using Dto = Har.Archive.Backend.Data.Services.DtoModels;

namespace Har.Archive.Backend.Api.Mappers
{
    public class HarArchiveMapperProfile : Profile
    {
        public HarArchiveMapperProfile()
        {
            CreateMap<Domain.HarFile, Dto.HarFile>();
        }
    }
}
