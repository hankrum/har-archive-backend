using Har.Archive.Backend.Data.Domain;
using Har.Archive.Backend.Infrastructure;
using System.Threading.Tasks;

namespace Har.Archive.Backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MsSqlDbContext context;
        private readonly IEfRepository<HarFile> harFiles;
        private readonly IEfRepository<Folder> folders;

        public UnitOfWork(
            MsSqlDbContext context,
            IEfRepository<HarFile> harFiles,
            IEfRepository<Folder> folders
            )
        {
            this.context = Guard.GetNotNullArgument(context, nameof(context));
            this.harFiles = Guard.GetNotNullArgument(harFiles, nameof(harFiles));
            this.folders = Guard.GetNotNullArgument(folders, nameof(folders));
        }

        public IEfRepository<HarFile> HarFiles
        {
            get
            {
                return this.harFiles;
            }
        }

        public IEfRepository<Folder> Folders
        {
            get
            {
                return this.folders;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}
