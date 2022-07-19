using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleAdminPortal.API.Domain;
using PeopleAdminPortal.API.Models;
using PeopleAdminPortal.API.Repositories;

namespace PeopleAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonsController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeopleAsync()
        {
            var persons = await _personRepository.GetPeopleAsync();
            return Ok(_mapper.Map<List<Domain.Person>>(persons));
        }
        [HttpGet("{personId}"), ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetPersonAsync([FromRoute] Guid personId)
        {
            var person = await _personRepository.GetPersonAsync(personId);
            if (person == null)
                return NotFound();

            return Ok(_mapper.Map<Domain.Person>(person));
        }
        [HttpPut("{personId}")]
        public async Task<IActionResult> UpdatePersonAsync([FromRoute] Guid personId, [FromBody] UpdatePersonRequest person)
        {
            if (await _personRepository.Exists(personId))
            {
                var updatedPerson = await _personRepository.UpdatePerson(personId, _mapper.Map<Models.Person>(person));
                if (updatedPerson != null)
                {
                    return Ok(_mapper.Map<Models.Person>(person));
                }
            }
            return NotFound();
        }
        [HttpDelete("{personId}")]
        public async Task<IActionResult> DeletePersonAsync([FromRoute] Guid personId)
        {
            if (await _personRepository.Exists(personId))
            {
                var person = await _personRepository.DeletePerson(personId);
                return Ok(_mapper.Map<Domain.Person>(person));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddPersonAsync([FromBody] AddPersonRequest request)
        {
            
            var person = await _personRepository.AddPerson(_mapper.Map<Models.Person>(request));
            return CreatedAtAction(nameof(GetPersonAsync), new { personId = person.Id },
                _mapper.Map<Domain.Person>(person));
        }

    }
}
