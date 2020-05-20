using System.Collections.Generic;
using System.Linq;
using Moq;
using PersonManagement.Data.Contracts.Entities;
using PersonManagement.Data.Contracts.IRepositories;

namespace PersonManagement.UnitTest.Common.MockFactories
{
    public static class ColorRepositoryMockFactory
    {
        public static Mock<IColorRepository> Mock { get; set; }

        public static Color TestColor { get; set; }

        public static List<Color> TestColors { get; set; }

        public static Mock<IColorRepository> Create()
        {
            Mock = new Mock<IColorRepository>();

            Mock.Setup(x => x.Init());

            TestColor = GetTestColor();
            TestColors = new List<Color> { TestColor };

            Mock.Setup(x => x.Find()).Returns(TestColors.AsQueryable());
            
            return Mock;
        }

        private static Color GetTestColor()
        {
            return new Color
            {
                Id = 1,
                Name = "blau"
            };
        }
    }
}