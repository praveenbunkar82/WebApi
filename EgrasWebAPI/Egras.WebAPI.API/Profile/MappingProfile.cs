using AutoMapper;
using Egras.Entities.DTO;
using Egras.Entities;

namespace EgrasWebAPI.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<MenuDto, Menu>();
            CreateMap<User, UserDto>();
            CreateMap<User, AddUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<Authenticate, AuthenticateDto>();
        }
    }
}
