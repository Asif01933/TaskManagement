
using System;
using TaskManagement.DTO;
using TaskManagement.Models;
using TaskManagement.Repositories;
using TaskManagement.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagement.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository<Person> _repository;
        
        public PersonService(IPersonRepository<Person> repository) => _repository = repository;

        public PersonDto CreatePerson(CreatePersonDto personRequest)
        {
            var newPerson = new Person()
            {
                Id = Guid.NewGuid().ToString(),
                Name = personRequest.Name,
                Designation = personRequest.Designation,
                Email = personRequest.Email,
                Address = personRequest.Address,
                Password = personRequest.Password
            };

            _repository.Add(newPerson);

            return new PersonDto()
            {
                Email = newPerson.Email,
                Designation = newPerson.Designation,
                Name = newPerson.Name,
                Address = newPerson.Address,
                Id = newPerson.Id
            };
        }

        public string UpdatePerson(UpdatePersonDto personRequest)
        {
            var existingPerson = _repository.FindById(personRequest.Id);

            _ = existingPerson ?? throw new Exception($"User with {personRequest.Id} doesn't exist");

            existingPerson.Email = personRequest.Email;
            existingPerson.Name = personRequest.Name;
            existingPerson.Designation = personRequest.Designation;
            existingPerson.Address = personRequest.Address;
            existingPerson.Password = personRequest.Password;

            _repository.Update(existingPerson);

            return existingPerson.Id;
        }
        public IEnumerable<PersonDto> GetPersons()
        {
            return _repository.GetAll.Select(x => new PersonDto()
            {
                Id = x.Id,
                Name = x.Name,
                Designation = x.Designation,
                Email = x.Email,
                Address = x.Address
            });
        }

       
        

    }
}
