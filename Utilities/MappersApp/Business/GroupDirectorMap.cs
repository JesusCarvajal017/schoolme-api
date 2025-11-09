using AutoMapper;
using Entity.Dtos.Business.GroupDirector;
using Entity.Model.Business;

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
                .ForMember(dest=> dest.FisrtName, opt => opt.MapFrom(t => t.Teacher.Person.FisrtName))
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(t => t.Teacher.Person.SecondLastName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(t => t.Teacher.Person.LastName))
                .ForMember(dest => dest.SecondLastName, opt => opt.MapFrom(t => t.Teacher.Person.SecondLastName))
                .ForMember(dest => dest.NameGroup, opt => opt.MapFrom(t => t.Groups.Name))

                .ReverseMap();
        }
    }
}