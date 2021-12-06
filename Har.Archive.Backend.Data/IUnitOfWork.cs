using Har.Archive.Backend.Data.Domain;
using System.Threading.Tasks;

namespace Har.Archive.Backend.Data
{
    public interface IUnitOfWork
    {
        IEfRepository<HarFile> HarFiles { get; }

        IEfRepository<Folder> Folders { get; }

        Task<int> SaveChanges();
    }
}
