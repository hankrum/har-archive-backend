using AutoMapper;
using Har.Archive.Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Dto = Har.Archive.Backend.Data.Services.DtoModels;

namespace Har.Archive.Backend.Data.Services.Services
{
    public class PathService : IPathService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PathService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = Guard.GetNotNullArgument(unitOfWork, nameof(unitOfWork));
            this.mapper = Guard.GetNotNullArgument(mapper, nameof(mapper));
        }

        public async Task<bool> PathExists(string path)
        {
            bool exists = await this.unitOfWork.Paths.All().AnyAsync(p => p.Text == path);

            return exists;
        }

        public async Task<Domain.Path> GetPathByText(string text)
        {
            var dboPath = await this.unitOfWork
                .Paths
                .All()
                .FirstOrDefaultAsync(path => path.Text == text);

            return dboPath;
        }

        public async Task<Domain.Path> Create(Dto.Path path)
        {
            bool exists = await this.PathExists(path.Text);

            if (exists)
            {
                return null;
            }

            var dbPath = this.mapper.Map<Domain.Path>(path);

            this.unitOfWork.Paths.Add(dbPath);

            await this.unitOfWork.SaveChangesAsync();

            return dbPath;
        }
    }
}
