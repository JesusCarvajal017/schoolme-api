using AutoMapper;
using Entity.Dtos.Business.CompositionAgenda;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class CompositionAgendaMap : Profile
    {
        public CompositionAgendaMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<CompositionAgendaQuestion, CompositionDto>().ReverseMap();
        }
    }
}