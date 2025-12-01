using AutoMapper;
using Entity.Dtos.Business.GroupDirector;
using Entity.Model.Business;
using Utilities.Helpers.Core;

namespace Utilities.MappersApp.Business
{
    public class GroupDirectorMap : Profile
    {
        public GroupDirectorMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<GroupDirector, GroupDirectorDto>().ReverseMap();

            CreateMap<GroupDirector, GroupDirectorQueryDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(t => $"{t.Teacher.Person.FisrtName} {t.Teacher.Person.LastName}"))
                .ForMember(dest => dest.FisrtName, opt => opt.MapFrom(t => t.Teacher.Person.FisrtName))
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(t => t.Teacher.Person.SecondLastName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(t => t.Teacher.Person.LastName))
                .ForMember(dest => dest.SecondLastName, opt => opt.MapFrom(t => t.Teacher.Person.SecondLastName))
                .ForMember(dest => dest.NameGroup, opt => opt.MapFrom(t => t.Groups.Name))

                .ReverseMap();

            CreateMap<GroupDirector, GroupsDirectorQueryDto>()
               .ForMember(d => d.TeacherId, o => o.MapFrom(s => s.TeacherId))
               .ForMember(d => d.GroupId, o => o.MapFrom(s => s.GroupId))
               .ForMember(d => d.AgendaId, o => o.MapFrom(s => s.Groups.AgendaId))
               .ForMember(d => d.NameGroup, o => o.MapFrom(s => s.Groups.Name))
               .ForMember(d => d.NameGrade, o => o.MapFrom(s => s.Groups.Grade.Name))
               .ForMember(d => d.AmountStudents, o => o.MapFrom(s => s.Groups.AmountStudents))
                .ForMember(d => d.AgendaState,
                    o => o.MapFrom(s => GroupDirectorHelpers.GetAgendaOperation(s)));
        }

    }
}