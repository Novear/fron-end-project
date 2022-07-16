using Microsoft.EntityFrameworkCore;

namespace PeopleAdminPortal.API.Models
{
    public class PersonAdminContext:DbContext
    {
        public PersonAdminContext(DbContextOptions<PersonAdminContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
