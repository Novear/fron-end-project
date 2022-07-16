using AutoMapper;
using PeopleAdminPortal.API.Domain;

namespace PeopleAdminPortal.API.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Person, Person>()
                .ReverseMap();
            CreateMap<Models.Gender, Gender>()
                .ReverseMap();
            CreateMap<Models.Address, Address>()
                .ReverseMap();
        }


    }
}
