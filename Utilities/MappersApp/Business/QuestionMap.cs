using AutoMapper;
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
                .ForMember(dest => dest.NameAnswer, opt => opt.MapFrom(t => t.TypeAswer.Name ))
               .ReverseMap();
        }
    }
}