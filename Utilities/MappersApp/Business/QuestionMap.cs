using AutoMapper;
using Entity.Dtos.Business.CompositionAgenda;
using Entity.Dtos.Business.Question;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class QuestionMap : Profile
    {
        public QuestionMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Question, QuestionDto>().ReverseMap();

            CreateMap<Question, QuestionQueryDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.QuestionOptions))
                .ForMember(dest => dest.NameAnswer, opt => opt.MapFrom(src => src.TypeAswer.Description));


            CreateMap<QuestionOption, QuestionOptionCompositionDto>()
                .ForMember(d => d.QuestionId, o => o.MapFrom(s => s.QuestionId));


            CreateMap<Question, QuestionCompositionQueryDto>()
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.QuestionOptions))
                .ForMember(dest => dest.NameAnswer, opt => opt.MapFrom(src => src.TypeAswer.Description));
        }
    }
}