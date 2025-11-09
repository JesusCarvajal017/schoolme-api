using AutoMapper;
using Entity.Dtos.Security.Rol;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class RolMap : Profile
    {
        public RolMap()
        {
            CreateMap<Rol, RolDto>().ReverseMap();

        }
    }
}