using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonManagement.Data.Contexts;
using PersonManagement.Data.Contracts.Entities;
using PersonManagement.Data.Contracts.IRepositories;

namespace PersonManagement.Data.Repositories
{
    public class PersonMsSqlRepository : IPersonRepository
    {
        private bool _isDisposed;
        private PersonManagementDbContext _context;

        public PersonMsSqlRepository(PersonManagementDbContext context)
        {
            _context = context;
        }

        ~PersonMsSqlRepository()
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
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }

                _isDisposed = true;
            }
        }

        public IQueryable<Person> Find()
        {
            return _context.Persons.Include(x => x.Color).AsNoTracking();
        }

        public Person Add(Person person)
        {
            person.Color = null;
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public List<Person> Add(List<Person> persons)
        {
            foreach (var person in persons)
            {
                person.Color = null;
            }

            _context.AddRange(persons);
            _context.SaveChanges();
            return persons;
        }
    }
}