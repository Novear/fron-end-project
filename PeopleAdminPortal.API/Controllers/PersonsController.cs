using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public PersonsController(IPersonRepository personRepository, IMapper mapper )
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeopleAsync() 
        {
            var persons = await _personRepository.GetPeopleAsync();
            return Ok(_mapper.Map<List<Person>>(persons));
        }
    }
}
