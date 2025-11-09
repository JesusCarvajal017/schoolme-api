using AutoMapper;
using Entity.Dtos.Parameters.Eps;
using Entity.Dtos.Parameters.Group;
using Entity.Dtos.Parameters.Rh;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class RhMap : Profile
    {
        public RhMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap <Rh, RhDto>().ReverseMap();
        }
    }
}