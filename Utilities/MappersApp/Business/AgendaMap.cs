using AutoMapper;
using Entity.Dtos.Business.Agenda;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class AgendaMap : Profile
    {
        public AgendaMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Agenda, AgendaDto>().ReverseMap();
        }
    }
}