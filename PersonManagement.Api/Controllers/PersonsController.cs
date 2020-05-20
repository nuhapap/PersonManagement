using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Api.Models;
using PersonManagement.Business.Contracts.Interfaces;
using PersonManagement.Business.Contracts.Models;

namespace PersonManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase, IDisposable
    {
        private bool _isDisposed;
        private IMapper _mapper;
        private IPersonService _personService;
        private IColorService _colorService;
        private IPersonImporter _personImporter;

        public PersonsController(IMapper mapper, IPersonService personService, IColorService colorService, IPersonImporter personImporter)
        {
            _mapper = mapper;
            _personService = personService;
            _colorService = colorService;
            _personImporter = personImporter;
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

                    if (_personImporter != null)
                    {
                        _personImporter.Dispose();
                        _personImporter = null;
                    }
                }

                _isDisposed = true;

            }
        }

        [HttpGet("/persons")]
        public IActionResult Get()
        {
            var persons = _personService.GetPersons();
            return new OkObjectResult(_mapper.Map<IEnumerable<PersonModel>>(persons));
        }

        [HttpGet("/persons/{id}")]
        public IActionResult GetById(int id)
        {
            var person = _personService.GetPersonById(id);
            return new OkObjectResult(_mapper.Map<PersonModel>(person));
        }

        [HttpGet("/persons/color/{color}")]
        public IActionResult GetByColor(string color)
        {
            var persons = _personService.GetPersonsByColor(color);
            return new OkObjectResult(_mapper.Map<IEnumerable<PersonModel>>(persons));
        }

        [HttpPost("/persons")]
        public IActionResult Post(PersonModel person)
        {
            if (!IsValidRequest(person))
            {
                return BadRequest(person);
            }

            var personToAdd = _mapper.Map<PersonModel, PersonDto>(person);
            personToAdd.Color = _colorService.GetColors().First(x => x.Name == person.Color);
            personToAdd.ColorId = _colorService.GetColors().First(x => x.Name == person.Color).Id;

            _personService.AddPerson(personToAdd);

            return new OkObjectResult("Added");
        }
        
        [HttpPost("/persons/import")]
        public IActionResult Import()
        {
            _personImporter.ImportPersons();
            return new OkObjectResult("Imported");
        }

        private bool IsValidRequest(PersonModel person)
        {
            if (string.IsNullOrEmpty(person.Name) ||
                string.IsNullOrEmpty(person.LastName) ||
                string.IsNullOrEmpty(person.City) ||
                string.IsNullOrEmpty(person.Zipcode))
            {
                return false;
            }

            if (!int.TryParse(person.Zipcode, out _))
            {
                return false;
            }

            var colorNames = _colorService.GetColors().Select(x => x.Name);

            if (!colorNames.Contains(person.Color))
            {
                return false;
            }

            return true;
        }
    }
}