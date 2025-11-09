using AutoMapper;
using Entity.Dtos.Security.Module;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class ModuleMap : Profile
    {
        public ModuleMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Module, ModuleDto>().ReverseMap();
        }
    }
}