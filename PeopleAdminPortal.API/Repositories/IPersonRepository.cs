using PeopleAdminPortal.API.Models;

namespace PeopleAdminPortal.API.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPeopleAsync();
    }
}
