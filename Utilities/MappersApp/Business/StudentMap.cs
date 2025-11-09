using AutoMapper;
using Entity.Dtos.Business.Student;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class StudentMap : Profile
    {
        public StudentMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Student, StudentDto>().ReverseMap();

            CreateMap<Student, StudentQueryDto>()
                            .ForMember(dest => dest.FullName, opt => opt.MapFrom(t => $"{t.Person.FisrtName} {t.Person.LastName}"))
                            .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(t => t.Person.DocumentTypeId))
                            .ForMember(dest => dest.Identification, opt => opt.MapFrom(t => t.Person.Identification))
                            .ForMember(dest => dest.AcronymDocument, opt => opt.MapFrom(t => t.Person.DocumentType.Acronym))
                            .ForMember(dest => dest.GroupName, opt => opt.MapFrom(t => t.Groups.Name))
                            .ReverseMap();
        }
    }
}