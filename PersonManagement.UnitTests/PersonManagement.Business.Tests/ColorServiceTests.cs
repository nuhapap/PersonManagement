using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonManagement.Business.Implementation;
using PersonManagement.UnitTest.Common.MockFactories;

namespace PersonManagement.UnitTests.PersonManagement.Business.Tests
{
    [TestClass]
    public class ColorServiceTests
    {
        [TestMethod]
        public void ColorService_GetColors_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var colorRepositoryMock = ColorRepositoryMockFactory.Create();
            var service = new ColorService(autoMapper, colorRepositoryMock.Object);

            var colors = service.GetColors().ToList();

            Assert.IsNotNull(colors);
            Assert.AreEqual(ColorRepositoryMockFactory.TestColors.Count, colors.Count);
            ColorRepositoryMockFactory.Mock.Verify(x => x.Find(), Times.Once);
        }

        [TestMethod]
        public void ColorService_Init_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var colorRepositoryMock = ColorRepositoryMockFactory.Create();
            var service = new ColorService(autoMapper, colorRepositoryMock.Object);

            service.Init();

            ColorRepositoryMockFactory.Mock.Verify(x => x.Find(), Times.Once);
        }
    }
}