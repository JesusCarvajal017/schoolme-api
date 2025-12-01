using AutoMapper;
using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class AgendaDayStudentMap : Profile
    {
        public AgendaDayStudentMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<AgendaDayStudent, AgendaDayStudentDto>().ReverseMap();

            CreateMap<AgendaDayStudent, AgendaDayStudentListDto>()
                .ForMember(d => d.AgendaDayStudentId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.StudentId, o => o.MapFrom(s => s.StudentId))
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.Student.Person.FisrtName + " " + s.Student.Person.LastName))
                .ForMember(d => d.Document, o => o.MapFrom(s => s.Student.Person.Identification))
                .ForMember(d => d.TypeDocumetation, o => o.MapFrom(s => s.Student.Person.DocumentType.Acronym));

            CreateMap<AgendaDayStudentListItem, AgendaDayStudentListDto>();

        }
    }
}