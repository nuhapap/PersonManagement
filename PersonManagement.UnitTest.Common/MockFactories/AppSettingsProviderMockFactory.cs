using Moq;
using PersonManagement.AppSettings;

namespace PersonManagement.UnitTest.Common.MockFactories
{
    public static class AppSettingsProviderMockFactory
    {
        public static Mock<IAppSettingsProvider> Mock { get; set; }

        public static Mock<IAppSettingsProvider> Create()
        {
            Mock = new Mock<IAppSettingsProvider>();

            Mock.Setup(x => x.CsvFilePath()).Returns(@"TestData\sample-input.csv");
            Mock.Setup(x => x.UseSql()).Returns(false);

            return Mock;
        }
    }
}