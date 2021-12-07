using AutoMapper;
using Har.Archive.Backend.Data.Services.DtoModels;
using Har.Archive.Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Har.Archive.Backend.Data.Services
{
    public class HarFileService : IHarFileService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        // TODO: fix DI

        public HarFileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = Guard.GetNotNullArgument(unitOfWork, nameof(unitOfWork));
            this.mapper = Guard.GetNotNullArgument(mapper, nameof(mapper));
        }

        public async Task<IEnumerable<HarFile>> All()
        {
            var harFilesQuery = await unitOfWork
                .HarFiles
                .All()
                .ToListAsync();

            var harFilesDto = harFilesQuery.Select(harFile => mapper.Map<HarFile>(harFile));

            return harFilesDto;
        }
    }
}
