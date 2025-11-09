using AutoMapper;
using Entity.Dtos.Parameters.Eps;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class EpsMap : Profile
    {
        public EpsMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap <Eps, EpsDto>().ReverseMap();
        }
    }
}