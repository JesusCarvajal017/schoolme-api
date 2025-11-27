using AutoMapper;
using Entity.Dtos.Business.StudentAnsware;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class StudentAnswareMap : Profile
    {
        public StudentAnswareMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<StudentAnswer, StudentAnswareDto>().ReverseMap();

            CreateMap<StudentAnswer, StudentAnswerInputDto>()
           .ForMember(d => d.OptionIds,
               o => o.MapFrom(s =>
                   s.SelectedOptions
                       .Select(so => so.QuestionOptionId)
                       .ToList()
               ));
        }
    }
}