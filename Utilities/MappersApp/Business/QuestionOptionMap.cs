using AutoMapper;
using Entity.Dtos.Business.Question;
using Entity.Dtos.Business.QuestionOption;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class QuestionOptionMap : Profile
    {
        public QuestionOptionMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<QuestionOption, QuestionOptionDto>().ReverseMap();


        


        }
    }
}