using System;
using System.Collections.Generic;
using PersonManagement.Business.Contracts.Models;

namespace PersonManagement.Business.Contracts.Interfaces
{
    public interface IPersonService : IDisposable
    {
        IEnumerable<PersonDto> GetPersons();

        PersonDto GetPersonById(int id);

        IEnumerable<PersonDto> GetPersonsByColor(string color);

        PersonDto AddPerson(PersonDto person);

        List<PersonDto> AddPerson(List<PersonDto> persons);
    }
}