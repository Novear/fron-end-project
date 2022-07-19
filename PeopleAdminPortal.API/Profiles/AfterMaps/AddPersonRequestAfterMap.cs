using AutoMapper;
using PeopleAdminPortal.API.Domain;

namespace PeopleAdminPortal.API.Profiles.AfterMaps
{
    public class AddPersonRequestAfterMap : IMappingAction<AddPersonRequest, Models.Person>
    {
        public void Process(AddPersonRequest source, Models.Person destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Models.Address()
            {
                Id= Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
