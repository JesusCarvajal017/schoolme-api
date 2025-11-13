using AutoMapper;
using Entity.Dtos.Business.Student;
using Entity.Dtos.Business.Teacher;
using Entity.Dtos.Especific.DataBasicComplete;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class StudentMap : Profile
    {
        public StudentMap()
        {

            CreateMap<Teacher, TeacherModelDto>().ReverseMap(); 

            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Student, StudentDto>().ReverseMap();

            CreateMap<Student, StudentQueryDto>()
                            .ForMember(dest => dest.FullName, opt => opt.MapFrom(t => $"{t.Person.FisrtName} {t.Person.LastName}"))
                            .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(t => t.Person.DocumentTypeId))
                            .ForMember(dest => dest.Identification, opt => opt.MapFrom(t => t.Person.Identification))
                            .ForMember(dest => dest.AcronymDocument, opt => opt.MapFrom(t => t.Person.DocumentType.Acronym))
                            .ForMember(dest => dest.GroupName, opt => opt.MapFrom(t => t.Groups.Name))

                            .ReverseMap();

            CreateMap<Student, CompleteDataPersonDto>()
               // Si quieres exponer PersonId en el DTO, mapealo así (si tu DTO tiene esa propiedad):
               // .ForMember(d => d.PersonId, o => o.MapFrom(s => s.PersonId))
               .IncludeMembers(t => t.Person);
        }
    }
}