using AutoMapper;
using Entity.Dtos.Business.AgendaDay;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class AgendaDayMap : Profile
    {
        public AgendaDayMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<AgendaDay, AgendaDayDto>().ReverseMap();
        }
    }
}