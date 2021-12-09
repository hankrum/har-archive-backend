using Har.Archive.Backend.Data.Domain;
using Har.Archive.Backend.Infrastructure;
using System.Threading.Tasks;

namespace Har.Archive.Backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MsSqlDbContext context;
        private readonly IEfRepository<HarFile> harFiles;
        private readonly IEfRepository<Path> paths;

        public UnitOfWork(
            MsSqlDbContext context,
            IEfRepository<HarFile> harFiles,
            IEfRepository<Path> paths
            )
        {
            this.context = Guard.GetNotNullArgument(context, nameof(context));
            this.harFiles = Guard.GetNotNullArgument(harFiles, nameof(harFiles));
            this.paths = Guard.GetNotNullArgument(paths, nameof(paths));
        }

        public IEfRepository<HarFile> HarFiles
        {
            get
            {
                return this.harFiles;
            }
        }

        public IEfRepository<Path> Paths
        {
            get
            {
                return this.paths;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
