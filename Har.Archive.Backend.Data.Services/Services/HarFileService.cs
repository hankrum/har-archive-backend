using AutoMapper;
using Dto = Har.Archive.Backend.Data.Services.DtoModels;
using Har.Archive.Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain = Har.Archive.Backend.Data.Domain;

namespace Har.Archive.Backend.Data.Services.Services
{
    public class HarFileService : IHarFileService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPathService pathService;
        private readonly IMapper mapper;

        public HarFileService(
            IUnitOfWork unitOfWork, 
            IPathService pathService,
            IMapper mapper)
        {
            this.unitOfWork = Guard.GetNotNullArgument(unitOfWork, nameof(unitOfWork));
            this.mapper = Guard.GetNotNullArgument(mapper, nameof(mapper));
            this.pathService = Guard.GetNotNullArgument(pathService, nameof(pathService));
        }

        public async Task<IEnumerable<Dto.HarFile>> AllByPath(string path)
        {
            var harFilesQuery = await unitOfWork
                .HarFiles
                .All()
                .Include(harFile => harFile.Path)
                .Where(harFile => harFile.Path.Text == path)
                .ToListAsync();

            var harFilesDto = harFilesQuery.Select(harFile => mapper.Map<Dto.HarFile>(harFile));

            return harFilesDto;
        }

        public async Task Create(Dto.HarFile harFile)
        {
            if (await this.HarFileExists(harFile))
            {
                return;
            }

            Domain.Path path  = await this.pathService.GetPathByText(harFile.Path.Text);

            if (path == null)
            {
                path = await this.pathService.Create(harFile.Path);
            }

            var harFileToAdd = mapper.Map<Domain.HarFile>(harFile);

            harFileToAdd.Path = null;
            harFileToAdd.PathId = path.Id;

            this.unitOfWork.HarFiles.Add(harFileToAdd);

            await this.unitOfWork.SaveChangesAsync();
        }

        private async Task<bool> HarFileExists(Dto.HarFile harFile)
        {
            var exists = await this.unitOfWork
                .HarFiles
                .All()
                .AnyAsync(hf => hf.Name == harFile.Name && hf.Path.Text == harFile.Path.Text && hf.Content == harFile.Content);

            return exists;
        }

        public async Task AddHarFiles(IEnumerable<Dto.HarFile> harFiles)
        {
            foreach (var harFile in harFiles)
            {
                await this.Create(harFile);
            }
        }
    }
}
