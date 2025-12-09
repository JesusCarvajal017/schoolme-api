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

            CreateMap<AgendaDay, AgendaDayAdminListDto>()
                .ForMember(d => d.AgendaDayId,
                    o => o.MapFrom(s => s.Id))
                .ForMember(d => d.AgendaId,
                    o => o.MapFrom(s => s.AgendaId))
                .ForMember(d => d.GroupId,
                    o => o.MapFrom(s => s.GroupId))
                .ForMember(d => d.AgendaName,
                    o => o.MapFrom(s => s.Agenda.Name))
                .ForMember(d => d.GroupName,
                    o => o.MapFrom(s => s.Group.Name))
                .ForMember(d => d.Date,
                    o => o.MapFrom(s => s.Date))
                .ForMember(d => d.State,
                    o => o.Ignore()); 
        }
    }
}