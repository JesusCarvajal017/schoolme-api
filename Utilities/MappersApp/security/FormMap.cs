using AutoMapper;
using Entity.Dtos.Security.Form;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class FormMap : Profile
    {
        public FormMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Form, FormDto>().ReverseMap();
        }
    }
}