using AutoMapper;
using Entity.Dtos.Parameters.Grade;
using Entity.Dtos.Parameters.Rh;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class TypeAnswareMap : Profile
    {
        public TypeAnswareMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap <TypeAnsware, TypeAnswareDto>().ReverseMap();
        }
    }
}