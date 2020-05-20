using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PersonManagement.Business.Contracts.Interfaces;
using PersonManagement.Business.Contracts.Models;
using PersonManagement.Data.Contracts.Entities;
using PersonManagement.Data.Contracts.IRepositories;

namespace PersonManagement.Business.Implementation
{
    public class PersonService : IPersonService
    {
        private IMapper _mapper;
        private IPersonRepository _personRepository;
        private bool _isDisposed;

        public PersonService(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
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
                    _mapper = null;

                    if (_personRepository != null)
                    {
                        _personRepository.Dispose();
                        _personRepository = null;
                    }
                }

                _isDisposed = true;
            }
        }

        public IEnumerable<PersonDto> GetPersons()
        {
            var persons = _personRepository.Find();
            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }

        public PersonDto GetPersonById(int id)
        {
            var person = _personRepository.Find().FirstOrDefault(x => x.Id == id);
            return _mapper.Map<PersonDto>(person);
        }

        public IEnumerable<PersonDto> GetPersonsByColor(string color)
        {
            var persons = _personRepository.Find().Where(x => x.Color != null && x.Color.Name == color);
            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }

        public PersonDto AddPerson(PersonDto person)
        {
            var addedPerson = _personRepository.Add(_mapper.Map<Person>(person));
            return _mapper.Map<PersonDto>(addedPerson);
        }

        public List<PersonDto> AddPerson(List<PersonDto> persons)
        {
            var addedPersons = _personRepository.Add(_mapper.Map<List<Person>>(persons));
            return _mapper.Map<List<PersonDto>>(addedPersons);
        }
    }
}