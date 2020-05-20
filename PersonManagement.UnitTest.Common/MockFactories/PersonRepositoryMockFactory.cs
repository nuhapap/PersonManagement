using System.Collections.Generic;
using System.Linq;
using Moq;
using PersonManagement.Data.Contracts.Entities;
using PersonManagement.Data.Contracts.IRepositories;

namespace PersonManagement.UnitTest.Common.MockFactories
{
    public static class PersonRepositoryMockFactory
    {
        public static Mock<IPersonRepository> Mock { get; set; }

        public static Person TestPerson { get; set; }

        public static List<Person> TestPersons { get; set; }

        public static Mock<IPersonRepository> Create()
        {
            Mock = new Mock<IPersonRepository>();

            TestPerson = GetTestPerson();
            TestPersons = new List<Person> { TestPerson };

            Mock.Setup(x => x.Find()).Returns(TestPersons.AsQueryable());
            Mock.Setup(x => x.Add(It.IsAny<Person>())).Callback<Person>(AddPerson);
            Mock.Setup(x => x.Add(It.IsAny<List<Person>>())).Callback<List<Person>>(AddPersons);

            return Mock;
        }

        private static Person GetTestPerson()
        {
            return new Person
            {
                Name = "John",
                LastName = "Doyle",
                Id = 1,
                Zipcode = "555",
                City = "Hamburg",
                ColorId = 1,
                Color = new Color { Id = 1, Name = "blau" }
            };
        }


        private static void AddPerson(Person person)
        {
            person.Id = TestPersons.Last().Id + 1;
            TestPersons.Add(person);
        }

        private static void AddPersons(List<Person> persons)
        {
            var nextId = TestPersons.Last().Id + 1;
            foreach (var person in persons)
            {
                person.Id = nextId;
                nextId++;
            }

            TestPersons.AddRange(persons);
        }
    }
}