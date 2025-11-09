using AutoMapper;
using Entity.Dtos.Business.Teacher;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class TeacherMap : Profile
    {
        public TeacherMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Teacher, TeacherDto>().ReverseMap();

            CreateMap<Teacher, TeacherReadDto>()
                  .ForMember(dest => dest.FullName, opt => opt.MapFrom(t => $"{t.Person.FisrtName} {t.Person.LastName}"))
                    .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(t => t.Person.DocumentTypeId))
                    .ForMember(dest => dest.Identification, opt => opt.MapFrom(t => t.Person.Identification))
                    .ForMember(dest => dest.AcronymDocument, opt => opt.MapFrom(t => t.Person.DocumentType.Acronym))
                .ReverseMap();
        }
    }
}