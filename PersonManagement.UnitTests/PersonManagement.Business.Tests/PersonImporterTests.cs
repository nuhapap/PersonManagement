using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonManagement.Business.Contracts.Models;
using PersonManagement.Business.Implementation;
using PersonManagement.UnitTest.Common.MockFactories;

namespace PersonManagement.UnitTests.PersonManagement.Business.Tests
{
    [TestClass]
    public class PersonImporterTests
    {
        [TestMethod]
        [DeploymentItem(@"TestData\sample-input.csv")]
        public void PersonImporter_ImportPersons_Should_Be_Valid_Test()
        {
            var appSettingsProviderMock = AppSettingsProviderMockFactory.Create();
            var personServiceMock = PersonServiceMockFactory.Create();
            var colorServiceMock = ColorServiceMockFactory.Create();
            var importer = new PersonImporter(appSettingsProviderMock.Object, personServiceMock.Object, colorServiceMock.Object);

            importer.ImportPersons();

            AppSettingsProviderMockFactory.Mock.Verify(x => x.CsvFilePath(), Times.Once);
            PersonServiceMockFactory.Mock.Verify(x => x.AddPerson(It.Is<List<PersonDto>>(y => y[0].Name == "Hans")), Times.Once);
        }
    }
}