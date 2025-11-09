using AutoMapper;
using Entity.Dtos.Security.ModuleForm;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class ModuleFormMap : Profile
    {
        public ModuleFormMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<ModuleForm, ModuleFormCreation>().ReverseMap();


            //lectura o exposición
            CreateMap<ModuleForm, ModuleFormDto>()
               .ForMember(dest => dest.ModuleName, opt => opt.MapFrom(src => src.Module.Name))
               .ForMember(dest => dest.FormName, opt => opt.MapFrom(src => src.Form.Name));
               //.ReverseMap();
        }
    }
}