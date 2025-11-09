using AutoMapper;
using Entity.Dtos.Business.Tution;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class TutionMap : Profile
    {
        public TutionMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Tutition, TutionDto>().ReverseMap();

            CreateMap<Tutition, TutionReadDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(t => $"{t.Student.Person.FisrtName} {t.Student.Person.LastName}"))
                .ForMember(dest=> dest.FisrtName, opt => opt.MapFrom(t => t.Student.Person.FisrtName))
                .ForMember(dest => dest.SecondName, opt => opt.MapFrom(t => t.Student.Person.SecondLastName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(t => t.Student.Person.LastName))
                .ForMember(dest => dest.SecondLastName, opt => opt.MapFrom(t => t.Student.Person.SecondLastName))
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(t => t.Grade.Name))

                .ReverseMap();
        }
    }
}