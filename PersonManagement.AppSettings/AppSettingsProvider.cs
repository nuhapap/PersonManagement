using System;
using Microsoft.Extensions.Options;

namespace PersonManagement.AppSettings
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private bool _isDisposed;
        private AppSettings _appSettings;

        public AppSettingsProvider(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        ~AppSettingsProvider()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _appSettings = null;
                }

                _isDisposed = true;
            }
        }

        public string CsvFilePath()
        {
            return _appSettings.CsvFilePath;
        }

        public bool UseSql()
        {
            return _appSettings.UseSql;
        }
    }
}