using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonManagement.UnitTest.Common.MockFactories;

namespace PersonManagement.UnitTests.PersonManagement.AppSettings.Tests
{
    [TestClass]
    public class AppSettingsProviderTests
    {
        [TestMethod]
        public void AppSettingsProvider_CsvFilePath_Should_Be_Correct_Test()
        {
            var provider = AppSettingsProviderMockFactory.Create().Object;

            var appSettingsValue = provider.CsvFilePath();

            Assert.AreEqual(@"TestData\sample-input.csv", appSettingsValue);
        }

        [TestMethod]
        public void AppSettingsProvider_UseSql_Should_Be_Correct_Test()
        {
            var provider = AppSettingsProviderMockFactory.Create().Object;

            var appSettingsValue = provider.UseSql();

            Assert.AreEqual(false, appSettingsValue);
        }
    }
}