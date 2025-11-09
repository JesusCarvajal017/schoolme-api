using AutoMapper;
using Entity.Dtos.Security.UserRol;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class RolUserMap : Profile
    {
        public RolUserMap()
        {
            CreateMap <UserRol, UserRolDto>()
                .ForMember(dest =>dest.NameUser , opt => opt.MapFrom(ur => ur.User.Person.FisrtName))
                .ForMember(dest => dest.RolName, opt => opt.MapFrom(ur => ur.Rol.Name))
                .ReverseMap();



            CreateMap<UserRol, UserRolCreateDtos>().ReverseMap();
        } 
   
    }
}
