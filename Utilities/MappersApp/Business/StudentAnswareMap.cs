using AutoMapper;
using Entity.Dtos.Business.QuestionOption;
using Entity.Dtos.Business.Student;
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
        }
    }
}