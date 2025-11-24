using AutoMapper;
using Entity.Dtos.Business.CompositionAgenda;
using Entity.Dtos.Business.Question;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class CompositionAgendaMap : Profile
    {
        public CompositionAgendaMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<CompositionAgendaQuestion, CompositionDto>().ReverseMap();


            CreateMap<CompositionQueryDto, CompositionAgendaQuestion>().ReverseMap();


            CreateMap<CompositionAgendaQuestion, QuestionQueryDto>()
                .ForMember(d => d.NameAnswer, o => o.MapFrom(s => s.Question.Text))
                .ForMember(d => d.TypeAnswerId, o => o.MapFrom(s => s.Question.TypeAnswerId))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Question.TypeAswer.Name))
                .ReverseMap();



        }
    }
}