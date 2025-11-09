using AutoMapper;
using Entity.Dtos.Business.Attendants;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class AttendantsMap : Profile
    {
        public AttendantsMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Attendants, AttendantsDto>().ReverseMap();

            CreateMap<Attendants, AttendantsQueryDto>()
                .ForMember(dest => dest.NameAttendant, opt => opt.MapFrom(t => $"{t.Person.FisrtName} {t.Person.LastName}"))
                .ForMember(dest => dest.AttendantId, opt => opt.MapFrom(t => t.PersonId))


                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(t => t.StudentId))
                .ForMember(dest => dest.NameStudent, opt => opt.MapFrom(t => $"{t.Student.Person.FisrtName} {t.Student.Person.LastName}"))
                .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(t => t.Student.Person.DocumentType.Id))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(t => t.Student.Person.Identification))
                .ForMember(dest => dest.AcronymDocument, opt => opt.MapFrom(t => t.Student.Person.DocumentType.Acronym))
                .ReverseMap();


            CreateMap<Attendants,  AttStudentsQueryDto>()
               .ForMember(dest => dest.NameStudent, opt => opt.MapFrom(t => $"{t.Student.Person.FisrtName} {t.Student.Person.LastName}"))
               .ForMember(dest => dest.StudentId, opt => opt.MapFrom(t => t.StudentId))


               .ForMember(dest => dest.AttendantId, opt => opt.MapFrom(t => t.PersonId))
               .ForMember(dest => dest.NameAttendant, opt => opt.MapFrom(t => $"{t.Person.FisrtName} {t.Person.LastName}"))
               .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(t => t.Person.DocumentType.Id))
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(t => t.Person.Identification))
               .ForMember(dest => dest.AcronymDocument, opt => opt.MapFrom(t => t.Person.DocumentType.Acronym))
               .ReverseMap();


            CreateMap<Attendants, AttQueryDto>()
               .ForMember(dest => dest.NameAttendant, opt => opt.MapFrom(t => $"{t.Person.FisrtName} {t.Person.LastName}"))
               .ForMember(dest => dest.AttendantId, opt => opt.MapFrom(t => t.PersonId))


        
               .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(t => t.Person.DocumentType.Id))
               .ForMember(dest => dest.Identification, opt => opt.MapFrom(t => t.Person.Identification))
               .ForMember(dest => dest.AcronymDocument, opt => opt.MapFrom(t => t.Person.DocumentType.Acronym))
               .ReverseMap();


        }
    }
}