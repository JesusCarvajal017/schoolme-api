using AutoMapper;
using Entity.Dtos.Security.Permission;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class PermissionMap : Profile
    {
        public PermissionMap()
        {
            CreateMap<Permission, PermissionDto>().ReverseMap();
        }
    }
}