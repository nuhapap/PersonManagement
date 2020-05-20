using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonManagement.Business.Contracts.Models;
using PersonManagement.Business.Implementation;

namespace PersonManagement.UnitTests.PersonManagement.Business.Tests
{
    [TestClass]
    public class PersonConverterTests
    {
        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example1_Should_Be_Valid_Test()
        {
            const string line = "Müller, Hans, 67742 Lauterecken, 1";
            var availableColors = GetTestColors();
            
            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Müller", person.LastName);
            Assert.AreEqual("Hans", person.Name);
            Assert.AreEqual("67742", person.Zipcode);
            Assert.AreEqual("Lauterecken", person.City);
            Assert.AreEqual(1, person.Color.Id);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example2_Should_Be_Valid_Test()
        {
            const string line = "Petersen, Peter, 18439 Stralsund, 2";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Petersen", person.LastName);
            Assert.AreEqual("Peter", person.Name);
            Assert.AreEqual("18439", person.Zipcode);
            Assert.AreEqual("Stralsund", person.City);
            Assert.AreEqual(2, person.Color.Id);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example3_Should_Be_Valid_Test()
        {
            const string line = "Johnson, Johnny, 88888 made up, 3";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Johnson", person.LastName);
            Assert.AreEqual("Johnny", person.Name);
            Assert.AreEqual("88888", person.Zipcode);
            Assert.AreEqual("made up", person.City);
            Assert.AreEqual(3, person.Color.Id);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example4_Should_Be_Valid_Test()
        {
            const string line = "Millenium, Milly, 77777 made up too, 4";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Millenium", person.LastName);
            Assert.AreEqual("Milly", person.Name);
            Assert.AreEqual("77777", person.Zipcode);
            Assert.AreEqual("made up too", person.City);
            Assert.AreEqual(4, person.Color.Id);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example5_Should_Be_Valid_Test()
        {
            const string line = "Müller, Jonas, 32323 Hansstadt, 5";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Müller", person.LastName);
            Assert.AreEqual("Jonas", person.Name);
            Assert.AreEqual("32323", person.Zipcode);
            Assert.AreEqual("Hansstadt", person.City);
            Assert.AreEqual(5, person.Color.Id);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example6_Should_Be_Valid_Test()
        {
            const string line = "Fujitsu, Tastatur, 42342 Japan, 6";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Fujitsu", person.LastName);
            Assert.AreEqual("Tastatur", person.Name);
            Assert.AreEqual("42342", person.Zipcode);
            Assert.AreEqual("Japan", person.City);
            Assert.AreEqual(6, person.Color.Id);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example7_Should_Be_Valid_Test()
        {
            const string line = "Andersson, Anders, 32132 Schweden - ☀, 2";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Andersson", person.LastName);
            Assert.AreEqual("Anders", person.Name);
            Assert.AreEqual("32132", person.Zipcode);
            Assert.AreEqual("Schweden - ☀", person.City);
            Assert.AreEqual(2, person.Color.Id);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example8_Should_Be_Valid_Test()
        {
            const string line = "Bart, Bertram,";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.IsNull(person);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example9_Should_Be_Valid_Test()
        {
            const string line = "12313 Wasweißich, 1";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.IsNull(person);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example10_Should_Be_Valid_Test()
        {
            const string line = "Gerber, Gerda, 76535 Woanders, 3";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Gerber", person.LastName);
            Assert.AreEqual("Gerda", person.Name);
            Assert.AreEqual("76535", person.Zipcode);
            Assert.AreEqual("Woanders", person.City);
            Assert.AreEqual(3, person.Color.Id);
        }

        [TestMethod]
        public void PersonConverter_ConvertFromString_By_Example11_Should_Be_Valid_Test()
        {
            const string line = "Klaussen, Klaus, 43246 Hierach, 2";
            var availableColors = GetTestColors();

            var person = PersonConverter.ConvertFromString(line, availableColors);

            Assert.AreEqual("Klaussen", person.LastName);
            Assert.AreEqual("Klaus", person.Name);
            Assert.AreEqual("43246", person.Zipcode);
            Assert.AreEqual("Hierach", person.City);
            Assert.AreEqual(2, person.Color.Id);
        }

        private List<ColorDto> GetTestColors()
        {
            var testColors = new List<ColorDto>();
            testColors.Add(new ColorDto { Id = 1, Name = "blau" });
            testColors.Add(new ColorDto { Id = 2, Name = "grün" });
            testColors.Add(new ColorDto { Id = 3, Name = "violett" });
            testColors.Add(new ColorDto { Id = 4, Name = "rot" });
            testColors.Add(new ColorDto { Id = 5, Name = "gelb" });
            testColors.Add(new ColorDto { Id = 6, Name = "türkis" });
            testColors.Add(new ColorDto { Id = 7, Name = "weiß" });
            return testColors;
        }
    }
}