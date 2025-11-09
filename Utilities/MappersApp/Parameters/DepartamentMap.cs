using AutoMapper;
using Entity.Dtos.Parameters.Departament;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class DepartamentMap : Profile
    {
        public DepartamentMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Departament, DepartamentDto>().ReverseMap();
        }
    }
}