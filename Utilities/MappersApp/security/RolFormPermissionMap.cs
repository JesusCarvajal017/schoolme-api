using AutoMapper;
using Entity.Dtos.Security.RolFormPermission;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class RolFormPermissionMap : Profile
    {
        public RolFormPermissionMap()
        {
            CreateMap<RolFormPermission, RolFormPermissionDto>()
                .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Rol.Name))
                 .ForMember(dest => dest.FormName, opt => opt.MapFrom(src => src.Form.Name))
                 .ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name));

            CreateMap<RolFormPermission, RolFormPermissionCreateDto>().ReverseMap();
        }
    }
}