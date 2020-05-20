using System;
using System.Collections.Generic;
using System.Linq;
using PersonManagement.Data.Contracts.Entities;

namespace PersonManagement.Data.Contracts.IRepositories
{
    public interface IPersonRepository : IDisposable
    {
        IQueryable<Person> Find();

        Person Add(Person person);

        List<Person> Add(List<Person> persons);
    }
}