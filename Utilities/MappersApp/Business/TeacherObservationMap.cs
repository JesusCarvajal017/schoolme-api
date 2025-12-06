using AutoMapper;
using Entity.Dtos.Business.TeacherObservation;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class TeacherObservationMap : Profile
    {
        public TeacherObservationMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<TeacherObservation, TeacherObservationDto>().ReverseMap();

            CreateMap<TeacherObservation, TeacherObservationQueryDto>()
                .ForMember(d => d.TeacherName,
                    o => o.MapFrom(s => s.Teacher.Person.FisrtName + " " + s.Teacher.Person.LastName))
                .ForMember(d => d.SubjectName,
                    o => o.MapFrom(s => s.AcademicLoad != null
                        ? s.AcademicLoad.Subject.Name
                        : string.Empty))
                .ForMember(d => d.GroupName,
                    o => o.MapFrom(s => s.AgendaDayStudent.AgendaDay.Group.Name))
                .ForMember(d => d.GradeName,
                    o => o.MapFrom(s => s.AgendaDayStudent.AgendaDay.Group.Grade.Name))
                .ForMember(d => d.AcademicLoadId,
                    o => o.MapFrom(s => s.AcademicLoadId));
        }
    }
}