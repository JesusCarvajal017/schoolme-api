using AutoMapper;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class MunicipalityMap : Profile
    {
        public MunicipalityMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap < Munisipality, MunicipalityDto>().ReverseMap();

            CreateMap<Munisipality, MunicipalityQueryDto>()
                .ForMember(dest=> dest.DepartamentName, opt=> opt.MapFrom(src => src.Departament.Name))
                .ReverseMap();
        }
    }
}