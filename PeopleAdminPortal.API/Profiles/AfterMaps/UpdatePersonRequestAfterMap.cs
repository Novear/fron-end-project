using AutoMapper;
using PeopleAdminPortal.API.Domain;

namespace PeopleAdminPortal.API.Profiles.AfterMaps
{
    public class UpdatePersonRequestAfterMap : IMappingAction<UpdatePersonRequest, Models.Person>
    {
        public void Process(UpdatePersonRequest source, Models.Person destination, ResolutionContext context)
        {
            destination.Address = new Models.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
