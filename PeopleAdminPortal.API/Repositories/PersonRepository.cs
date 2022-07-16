using Microsoft.EntityFrameworkCore;
using PeopleAdminPortal.API.Models;

namespace PeopleAdminPortal.API.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonAdminContext _context;
        public PersonRepository(PersonAdminContext context)
        {
            _context = context;
        }
        public async Task<List<Person>> GetPeopleAsync()
        {
            return await _context.Person.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
