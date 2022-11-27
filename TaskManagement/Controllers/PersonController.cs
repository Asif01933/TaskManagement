using TaskManagement.DTO;
using TaskManagement.Models;
using TaskManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskManagement.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Controllers
{
    
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;


        public PersonController(IPersonService personService)
            => _personService = personService;

        [HttpPost]
        [Route("api/new-person")]
        public IActionResult Create(CreatePersonDto personRequest)
        {
            return Ok(_personService.CreatePerson(personRequest));
        }

        [HttpPut]
        [Route("api/person")]
        public IActionResult Update(UpdatePersonDto personRequest)
        {
            try
            {
                return Ok(_personService.UpdatePerson(personRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/person-lists")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_personService.GetPersons());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
