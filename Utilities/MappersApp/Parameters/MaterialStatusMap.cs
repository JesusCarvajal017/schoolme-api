using AutoMapper;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class MaterialStatusMap : Profile
    {
        public MaterialStatusMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap <MaterialStatus, MaterialStatusDto>().ReverseMap();
        }
    }
}