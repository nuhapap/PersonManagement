using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PersonManagement.AppSettings;
using PersonManagement.Business.Contracts.Interfaces;
using PersonManagement.Business.Contracts.Models;

namespace PersonManagement.Business.Implementation
{
    public class PersonImporter : IPersonImporter
    {
        private IAppSettingsProvider _appSettingsProvider;
        private IPersonService _personService;
        private IColorService _colorService;
        private bool _isDisposed;

        public PersonImporter(IAppSettingsProvider appSettingsProvider, IPersonService personService, IColorService colorService)
        {
            _appSettingsProvider = appSettingsProvider;
            _personService = personService;
            _colorService = colorService;
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
                    if (_appSettingsProvider != null)
                    {
                        _appSettingsProvider.Dispose();
                        _appSettingsProvider = null;
                    }

                    if (_personService != null)
                    {
                        _personService.Dispose();
                        _personService = null;
                    }

                    if (_colorService != null)
                    {
                        _colorService.Dispose();
                        _colorService = null;
                    }
                }

                _isDisposed = true;
            }
        }

        public void ImportPersons()
        {
            _colorService.Init();

            var availableColors = _colorService.GetColors();
            var path = _appSettingsProvider.CsvFilePath();
            var lines = File.ReadLines(path);
            var personsToAdd = new List<PersonDto>();
            foreach (var line in lines)
            {
                var person = PersonConverter.ConvertFromString(line, availableColors);
                if (person != null)
                {
                    personsToAdd.Add(person);
                }
            }

            _personService.AddPerson(personsToAdd);
        }
    }
}