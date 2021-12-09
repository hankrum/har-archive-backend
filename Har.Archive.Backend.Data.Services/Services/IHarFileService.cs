using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = Har.Archive.Backend.Data.Services.DtoModels;

namespace Har.Archive.Backend.Data.Services.Services
{
    public interface IHarFileService
    {
        Task<IEnumerable<Dto.HarFile>> All();

        Task Create(Dto.HarFile harFile);

        Task AddHarFiles(IEnumerable<Dto.HarFile> harFiles);
    }
}
