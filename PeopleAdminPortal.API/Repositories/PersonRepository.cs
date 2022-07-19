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

        public async Task<Person> GetPersonAsync(Guid personId)
        {
            return await _context.Person
                .Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x=>x.Id == personId);
        }
        public async Task<bool> Exists(Guid personId)
        {
            return await _context.Person.AnyAsync(x => x.Id == personId);
        }
        public async Task<Person> UpdatePerson(Guid personId, Person request)
        {

            var existingPerson = await GetPersonAsync(personId);
            if (existingPerson != null)
            {
                existingPerson.FirstName = request.FirstName;
                existingPerson.LastName = request.LastName;
                existingPerson.DateOfBirth = request.DateOfBirth;
                existingPerson.Email = request.Email;
                existingPerson.Mobile = request.Mobile; 
                existingPerson.GenderId= request.GenderId;
                existingPerson.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingPerson.Address.PostalAddress = request.Address.PostalAddress;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw;
                }
                
                return existingPerson;
            }
            return null;
        }

        public async Task<Person> DeletePerson(Guid personId)
        {
            var existingPerson = await GetPersonAsync(personId);
            if (existingPerson != null)
            {
                 _context.Person.Remove(existingPerson);
                await _context.SaveChangesAsync();
                return existingPerson;
            }
            return null;
        }

        public async Task<Person> AddPerson(Person request)
        {
            var person = await _context.Person.AddAsync(request);
            await _context.SaveChangesAsync();
            return person.Entity;
        }
    }
}
