using AutoMapper;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class GroupMap : Profile
    {
        public GroupMap()
        {
            CreateMap<Groups, GroupsDto>().ReverseMap();
            CreateMap<Groups,GroupsAgendaDto>().ReverseMap();

            CreateMap<Groups, GroupsQueryDto>()
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(g => g.Grade.Name))
                .ReverseMap();
        }
    }
}