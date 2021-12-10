using AutoFixture;
using AutoMapper;
using Har.Archive.Backend.Data;
using Har.Archive.Backend.Data.Domain;
using Har.Archive.Backend.Data.Services.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Har.Archive.Backend.Api.Data.Services.Tests.Services.HarFileServiceTests
{
    public class AllByPath_Should
    {
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly Mock<IPathService> pathServiceMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly Fixture fixture;

        public AllByPath_Should()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            pathServiceMock = new Mock<IPathService>();
            mapperMock = new Mock<IMapper>();
            fixture = new Fixture();
        }

        [Fact]
        public async Task ReturnProperData()
        {
            var path = fixture.Create<string>();

            var pathEntry = fixture.Build<Path>()
                .With(p => p.Text, path)
                .Create();

            var harFile = fixture.Build<HarFile>()
                .With(h => h.Path, pathEntry)
                .Create();

            var repositoryMock = new Mock<IEfRepository<HarFile>>();
            var expectedRepository = fixture.Create<IEfRepository<HarFile>>();
            expectedRepository.Add(harFile);

            // unitOfWorkMock.Setup(u => u.HarFiles).Returns(expectedQuery);
        }
    }
}
