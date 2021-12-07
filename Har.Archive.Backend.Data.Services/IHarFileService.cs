using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = Har.Archive.Backend.Data.Services.DtoModels;

namespace Har.Archive.Backend.Data.Services
{
    public interface IHarFileService
    {
        Task<IEnumerable<Dto.HarFile>> All();
    }
}
