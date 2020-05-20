using Moq;
using PersonManagement.Business.Contracts.Interfaces;

namespace PersonManagement.UnitTest.Common.MockFactories
{
    public static class PersonImporterMockFactory
    {
        public static Mock<IPersonImporter> Mock { get; set; }

        public static Mock<IPersonImporter> Create()
        {
            Mock = new Mock<IPersonImporter>();

            Mock.Setup(x => x.ImportPersons());

            return Mock;
        }
    }
}