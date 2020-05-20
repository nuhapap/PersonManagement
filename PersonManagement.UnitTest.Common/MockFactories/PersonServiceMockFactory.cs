using System.Collections.Generic;
using Moq;
using PersonManagement.Business.Contracts.Interfaces;
using PersonManagement.Business.Contracts.Models;

namespace PersonManagement.UnitTest.Common.MockFactories
{
    public static class PersonServiceMockFactory
    {
        public static Mock<IPersonService> Mock { get; set; }
        
        public static PersonDto TestPerson { get; set; }

        public static List<PersonDto> TestPersons { get; set; }

        public static Mock<IPersonService> Create()
        {
            Mock = new Mock<IPersonService>();

            TestPerson = GetTestPerson();
            TestPersons = new List<PersonDto> { TestPerson };
            Mock.Setup(x => x.GetPersons()).Returns(TestPersons);
            Mock.Setup(x => x.GetPersonById(It.IsAny<int>())).Returns(TestPerson);
            Mock.Setup(x => x.GetPersonsByColor(It.IsAny<string>())).Returns(TestPersons);
            Mock.Setup(x => x.AddPerson(It.IsAny<PersonDto>())).Callback<PersonDto>(AddPerson);

            return Mock;
        }

        private static void AddPerson(PersonDto person)
        {
            TestPersons.Add(person);
        }

        private static PersonDto GetTestPerson()
        {
            return new PersonDto
            {
                Name = "John",
                LastName = "Doyle",
                Id = 1,
                Zipcode = "555",
                City = "Hamburg",
                ColorId = 1,
                Color = new ColorDto
                {
                    Id = 1,
                    Name = "blau"
                }
            };
        }
    }
}