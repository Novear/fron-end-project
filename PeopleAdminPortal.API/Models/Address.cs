using System.ComponentModel.DataAnnotations;

namespace PeopleAdminPortal.API.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid PersonId { get; set; }
    }
}
