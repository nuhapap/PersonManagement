using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonManagement.Business.Contracts.Models;
using PersonManagement.Business.Implementation;
using PersonManagement.UnitTest.Common.MockFactories;

namespace PersonManagement.UnitTests.PersonManagement.Business.Tests
{
    [TestClass]
    public class PersonServiceTests
    {
        [TestMethod]
        public void PersonService_GetPersons_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personRepositoryMock = PersonRepositoryMockFactory.Create();
            var service = new PersonService(autoMapper, personRepositoryMock.Object);

            var persons = service.GetPersons().ToList();

            Assert.IsNotNull(persons);
            Assert.AreEqual(PersonRepositoryMockFactory.TestPersons.Count, persons.ToList().Count);
            Assert.AreEqual(PersonRepositoryMockFactory.TestPerson.Name, persons[0].Name);
            PersonRepositoryMockFactory.Mock.Verify(x => x.Find(), Times.Once);
        }

        [TestMethod]
        public void PersonService_GetPersonById_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personRepositoryMock = PersonRepositoryMockFactory.Create();
            var service = new PersonService(autoMapper, personRepositoryMock.Object);

            var person = service.GetPersonById(PersonRepositoryMockFactory.TestPerson.Id);

            Assert.IsNotNull(person);
            Assert.AreEqual(PersonRepositoryMockFactory.TestPerson.Id, person.Id);
            PersonRepositoryMockFactory.Mock.Verify(x => x.Find(), Times.Once);
        }

        [TestMethod]
        public void PersonService_GetPersonByColor_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personRepositoryMock = PersonRepositoryMockFactory.Create();
            var service = new PersonService(autoMapper, personRepositoryMock.Object);

            var persons = service.GetPersonsByColor(PersonRepositoryMockFactory.TestPerson.Color.Name).ToList();

            Assert.IsNotNull(persons);
            Assert.AreEqual(PersonRepositoryMockFactory.TestPersons.Count, persons.ToList().Count);
            Assert.AreEqual(PersonRepositoryMockFactory.TestPerson.Name, persons[0].Name);
            PersonRepositoryMockFactory.Mock.Verify(x => x.Find(), Times.Once);
        }

        [TestMethod]
        public void PersonService_AddPerson_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personRepositoryMock = PersonRepositoryMockFactory.Create();
            var service = new PersonService(autoMapper, personRepositoryMock.Object);
            var newPerson = GetTestPerson("max");

            service.AddPerson(newPerson);

            Assert.AreEqual(PersonRepositoryMockFactory.TestPersons[1].Name, newPerson.Name);
        }

        [TestMethod]
        public void PersonService_AddPerson_With_List_Should_Be_Valid_Test()
        {
            var autoMapper = AutoMapperFactory.GetMapper();
            var personRepositoryMock = PersonRepositoryMockFactory.Create();
            var service = new PersonService(autoMapper, personRepositoryMock.Object);
            var newPerson = GetTestPerson("max");
            var newPerson2 = GetTestPerson("maxin");

            service.AddPerson(new List<PersonDto> { newPerson, newPerson2 });

            Assert.AreEqual(PersonRepositoryMockFactory.TestPersons[1].Name, newPerson.Name);
            Assert.AreEqual(PersonRepositoryMockFactory.TestPersons[2].Name, newPerson2.Name);
        }

        private PersonDto GetTestPerson(string name)
        {
            return new PersonDto
            {
                Name = name,
                LastName = "Mustermann",
                City = "Irgendwo",
                Zipcode = "555",
                ColorId = 1,
                Color = new ColorDto { Id = 1, Name = "blau" }
            };
        }
    }
}