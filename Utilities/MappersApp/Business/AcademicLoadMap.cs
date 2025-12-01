using AutoMapper;
using Entity.Dtos.Business.AcademicLoad;
using Entity.Enum;
using Entity.Model.Business;
using Utilities.helpers;
using DaysFlags = Entity.Enum.Days;

namespace Utilities.MappersApp.Business
{
    public class AcademicLoadMap : Profile
    {
        public AcademicLoadMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<AcademicLoad, AcademicLoadDto>().ReverseMap();

            CreateMap<AcademicLoad, AcademicLoadReadDto>()
            .ForMember(d => d.Days, o => o.MapFrom(s =>
                ((DaysFlags)(s.Days ?? 0)).ToTexts().ToArray()
            ))
            .ForMember(d => d.FullName, op => op.MapFrom(p => $"{p.Teacher.Person.FisrtName} {p.Teacher.Person.LastName}"))
            .ForMember(d => d.SubjectName, op => op.MapFrom(p => p.Subject.Name))
            .ForMember(d => d.GroupName, op => op.MapFrom(p => p.Group.Name));

            CreateMap<AcademicLoad, LoadByDayReadDto>()
                .ForMember(d => d.TeacherId, op => op.MapFrom(p => p.TeacherId))
                .ForMember(d => d.FullName, op => op.MapFrom(p => $"{p.Teacher.Person.FisrtName} {p.Teacher.Person.LastName}"))
                .ForMember(d => d.SubjectId, op => op.MapFrom(p => p.SubjectId))
                .ForMember(d => d.SubjectName, op => op.MapFrom(p => p.Subject.Name))
                .ForMember(d => d.GroupId, op => op.MapFrom(p => p.GroupId))
                .ForMember(d => d.GroupName, op => op.MapFrom(p => p.Group.Name))
                .ForMember(d => d.CountStudents, op => op.MapFrom(p => p.Group.AmountStudents));
        }
    }
}