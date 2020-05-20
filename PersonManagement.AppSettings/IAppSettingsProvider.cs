using System;

namespace PersonManagement.AppSettings
{
    public interface IAppSettingsProvider : IDisposable
    {
        string CsvFilePath();

        bool UseSql();
    }
}