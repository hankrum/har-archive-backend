using System.Threading.Tasks;
using Dto = Har.Archive.Backend.Data.Services.DtoModels;

namespace Har.Archive.Backend.Data.Services.Services
{
    public interface IPathService
    {
        Task<Domain.Path> Create(Dto.Path path);

        Task<bool> PathExists(string path);

        Task<Domain.Path> GetPathByText(string text);
    }
}
