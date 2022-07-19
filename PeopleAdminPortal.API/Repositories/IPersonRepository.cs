using PeopleAdminPortal.API.Models;

namespace PeopleAdminPortal.API.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPeopleAsync();
        Task<Person> GetPersonAsync(Guid personId);
        Task<bool> Exists(Guid personId);
        Task<Person> UpdatePerson(Guid personId, Person request);
        Task<Person> DeletePerson(Guid personId);
        Task<Person> AddPerson(Person request);
    }
}
