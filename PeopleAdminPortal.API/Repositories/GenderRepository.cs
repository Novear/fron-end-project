using Microsoft.EntityFrameworkCore;
using PeopleAdminPortal.API.Models;

namespace PeopleAdminPortal.API.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly PersonAdminContext _context;
        public GenderRepository(PersonAdminContext context)
        {
            _context = context;
        }
        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Gender.ToListAsync();
        }
    }
}
