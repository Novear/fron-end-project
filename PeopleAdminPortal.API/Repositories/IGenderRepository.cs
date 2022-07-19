using PeopleAdminPortal.API.Models;

namespace PeopleAdminPortal.API.Repositories
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetGendersAsync();

    }
}
