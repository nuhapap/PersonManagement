using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonManagement.Api.Controllers;
using PersonManagement.Api.Models;
using PersonManagement.Business.Contracts.Models;
using PersonManagement.UnitTest.Common.MockFactories;

namespace PersonManagement.UnitTests.PersonManagement.Api.Tests
{
    [TestClass]
    public class PersonsControllerTests
    {
        [TestMethod]
        public void PersonController_Get_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personServiceMock = PersonServiceMockFactory.Create();
            var colorServiceMock = ColorServiceMockFactory.Create();
            var personImporter = PersonImporterMockFactory.Create();
            var controller = new PersonsController(autoMapper, personServiceMock.Object, colorServiceMock.Object, personImporter.Object);

            var actionResult = controller.Get();
            
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var persons = okObjectResult.Value as IEnumerable<PersonModel>;
            Assert.IsNotNull(persons);
            PersonServiceMockFactory.Mock.Verify(x => x.GetPersons(), Times.Once);
        }

        [TestMethod]
        public void PersonController_GetById_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personServiceMock = PersonServiceMockFactory.Create();
            var colorServiceMock = ColorServiceMockFactory.Create();
            var personImporter = PersonImporterMockFactory.Create();
            var controller = new PersonsController(autoMapper, personServiceMock.Object, colorServiceMock.Object, personImporter.Object);

            var actionResult = controller.GetById(PersonServiceMockFactory.TestPerson.Id);

            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var person = okObjectResult.Value as PersonModel;
            Assert.IsNotNull(person);
            PersonServiceMockFactory.Mock.Verify(x => x.GetPersonById(PersonServiceMockFactory.TestPerson.Id), Times.Once);
        }

        [TestMethod]
        public void PersonController_GetByColor_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personServiceMock = PersonServiceMockFactory.Create();
            var colorServiceMock = ColorServiceMockFactory.Create();
            var personImporter = PersonImporterMockFactory.Create();
            var controller = new PersonsController(autoMapper, personServiceMock.Object, colorServiceMock.Object, personImporter.Object);

            var actionResult = controller.GetByColor(PersonServiceMockFactory.TestPerson.Color.Name);
            
            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var person = okObjectResult.Value as IEnumerable<PersonModel>;
            Assert.IsNotNull(person);
            PersonServiceMockFactory.Mock.Verify(x => x.GetPersonsByColor(PersonServiceMockFactory.TestPerson.Color.Name), Times.Once);
        }

        [TestMethod]
        public void PersonController_Post_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personServiceMock = PersonServiceMockFactory.Create();
            var colorServiceMock = ColorServiceMockFactory.Create();
            var personImporter = PersonImporterMockFactory.Create();
            var controller = new PersonsController(autoMapper, personServiceMock.Object, colorServiceMock.Object, personImporter.Object);
            var newPerson = new PersonModel
            {
                Name = "Max",
                LastName = "Mustermann",
                City = "Irgendwo",
                Zipcode = "555",
                Color = "blau"
            };

            var actionResult = controller.Post(newPerson);

            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var message = okObjectResult.Value as string;
            Assert.AreEqual("Added", message);
            PersonServiceMockFactory.Mock.Verify(x => x.AddPerson(It.Is<PersonDto>(match => match.Name == newPerson.Name)), Times.Once);
        }

        [TestMethod]
        public void PersonController_Post_With_Invalid_Request_Should_Return_Bad_Request_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personServiceMock = PersonServiceMockFactory.Create();
            var colorServiceMock = ColorServiceMockFactory.Create();
            var personImporter = PersonImporterMockFactory.Create();
            var controller = new PersonsController(autoMapper, personServiceMock.Object, colorServiceMock.Object, personImporter.Object);
            var newPerson = GetTestPersonModel("", "blau");

            var actionResult = controller.Post(newPerson);

            var badRequestResult = actionResult as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
        }

        [TestMethod]
        public void PersonController_Post_With_Invalid_Color_Request_Should_Return_Bad_Request_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personServiceMock = PersonServiceMockFactory.Create();
            var colorServiceMock = ColorServiceMockFactory.Create();
            var personImporter = PersonImporterMockFactory.Create();
            var controller = new PersonsController(autoMapper, personServiceMock.Object, colorServiceMock.Object, personImporter.Object);
            var newPerson = GetTestPersonModel("Max", "bunt");

            var actionResult = controller.Post(newPerson);

            var badRequestResult = actionResult as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
        }

        [TestMethod]
        public void PersonController_Import_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personServiceMock = PersonServiceMockFactory.Create();
            var colorServiceMock = ColorServiceMockFactory.Create();
            var personImporter = PersonImporterMockFactory.Create();
            var controller = new PersonsController(autoMapper, personServiceMock.Object, colorServiceMock.Object, personImporter.Object);

            var actionResult = controller.Import();

            var okObjectResult = actionResult as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var message = okObjectResult.Value as string;
            Assert.AreEqual("Imported", message);
            PersonImporterMockFactory.Mock.Verify(x => x.ImportPersons(), Times.Once);
        }

        private PersonModel GetTestPersonModel(string name, string color)
        {
            return new PersonModel
            {
                Name = name,
                LastName = "Mustermann",
                City = "Irgendwo",
                Zipcode = "555",
                Color = color
            };
        }
    }
}