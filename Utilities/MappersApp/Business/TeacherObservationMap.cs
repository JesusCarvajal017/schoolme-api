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
        }
    }
}