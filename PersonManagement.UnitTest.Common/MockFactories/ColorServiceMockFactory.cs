using System.Collections.Generic;
using Moq;
using PersonManagement.Business.Contracts.Interfaces;
using PersonManagement.Business.Contracts.Models;

namespace PersonManagement.UnitTest.Common.MockFactories
{
    public static class ColorServiceMockFactory
    {
        public static Mock<IColorService> Mock { get; set; }

        public static PersonDto TestPerson { get; set; }

        public static List<PersonDto> TestPersons { get; set; }

        public static Mock<IColorService> Create()
        {
            Mock = new Mock<IColorService>();

            Mock.Setup(x => x.Init());
            var testColors = GetTestColors();
            Mock.Setup(x => x.GetColors()).Returns(testColors);

            return Mock;
        }

        private static List<ColorDto> GetTestColors()
        {
            return new List<ColorDto>
            {
                new ColorDto { Id = 1, Name = "blau" },
                new ColorDto { Id = 2, Name = "grün" },
                new ColorDto { Id = 3, Name = "violett" },
                new ColorDto { Id = 4, Name = "rot" },
                new ColorDto { Id = 5, Name = "gelb" },
                new ColorDto { Id = 6, Name = "türkis" },
                new ColorDto { Id = 7, Name = "weiß" },
            };
        }
    }
}