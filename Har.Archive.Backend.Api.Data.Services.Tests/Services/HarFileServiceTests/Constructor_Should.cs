using AutoMapper;
using Har.Archive.Backend.Data;
using Har.Archive.Backend.Data.Services.Services;
using Moq;
using System;
using Xunit;

namespace Har.Archive.Backend.Api.Data.Services.Tests.Services.HarFileServiceTests
{
    public class Constructor_Should
    {
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly Mock<IPathService> pathServiceMock;
        private readonly Mock<IMapper> mapperMock;

        public Constructor_Should()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            pathServiceMock = new Mock<IPathService>();
            mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public void ThrowNullArgumentException_WhenUnitOfWorkIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new HarFileService(null, pathServiceMock.Object, mapperMock.Object));
        }

        [Fact]
        public void ThrowNullArgumentException_WhenPathServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new HarFileService(unitOfWorkMock.Object, null, mapperMock.Object));
        }

        [Fact]
        public void ThrowNullArgumentException_WhenMapperIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new HarFileService(unitOfWorkMock.Object, pathServiceMock.Object, null));
        }
    }
}
