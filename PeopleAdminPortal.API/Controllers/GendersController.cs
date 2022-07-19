using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleAdminPortal.API.Domain;
using PeopleAdminPortal.API.Repositories;

namespace PeopleAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GendersController(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenders() 
        {
            var genderList = await _genderRepository.GetGendersAsync();
            if (genderList == null || !genderList.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<Gender>>(genderList));
        }
    } 
}
