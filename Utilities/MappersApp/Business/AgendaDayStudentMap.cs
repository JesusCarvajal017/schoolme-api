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
        }
    }
}