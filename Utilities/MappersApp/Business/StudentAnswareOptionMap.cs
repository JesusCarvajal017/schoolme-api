using AutoMapper;
using Entity.Dtos.Business.StudentAnswareOption;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class StudentAnswareOptionMap : Profile
    {
        public StudentAnswareOptionMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<StudentAnswerOption, StudentAnswareOptionDto>().ReverseMap();
        }
    }
}