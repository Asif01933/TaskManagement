using TaskManagement.DTO;
using System.Collections.Generic;
namespace TaskManagement.Services
{
    public interface IPersonService
    {
        PersonDto CreatePerson(CreatePersonDto personRequest);
        string UpdatePerson(UpdatePersonDto personRequest);
        IEnumerable<PersonDto> GetPersons();

       

    }
}
