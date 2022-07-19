using AutoMapper;
using PeopleAdminPortal.API.Domain;
using PeopleAdminPortal.API.Profiles.AfterMaps;

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
            CreateMap<UpdatePersonRequest, Models.Person>()
                
                //.ForMember(dest => dest.Address.PhysicalAddress, (opt) => opt.MapFrom(src => src.PhysicalAddress))
                //.ForMember(dest => dest.Address.PostalAddress, (opt) => opt.MapFrom(src => src.PostalAddress));
                .AfterMap<UpdatePersonRequestAfterMap>().ReverseMap();
            CreateMap<AddPersonRequest, Models.Person>()
                .AfterMap<AddPersonRequestAfterMap>().ReverseMap();
        }
    }
}
