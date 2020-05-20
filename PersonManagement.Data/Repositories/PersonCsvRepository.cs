using System;
using System.Collections.Generic;
using System.Linq;
using PersonManagement.Data.Contracts.Entities;
using PersonManagement.Data.Contracts.IRepositories;

namespace PersonManagement.Data.Repositories
{
    public class PersonCsvRepository : IPersonRepository
    {
        private bool _isDisposed;
        private static readonly List<Person> Persons = new List<Person>();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
            }
        }
        
        public IQueryable<Person> Find()
        {
            return Persons.AsQueryable();
        }

        public Person Add(Person person)
        {
            var nextId = GetNextId();
            person.Id = nextId;
            Persons.Add(person);
            return person;
        }

        public List<Person> Add(List<Person> persons)
        {
            foreach (var person in persons)
            {
                var nextId = GetNextId();
                person.Id = nextId;
                Persons.Add(person);
            }

            return persons;
        }

        private int GetNextId()
        {
            var lastPerson = Persons.LastOrDefault();
            if (lastPerson != null)
            {
                return lastPerson.Id + 1;
            }

            return 1;
        }
    }
}