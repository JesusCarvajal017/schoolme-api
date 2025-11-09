using AutoMapper;
using Entity.Dtos.Parameters.Subject;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class SubjectMap : Profile
    {
        public SubjectMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap <Subject, SubjectDto>().ReverseMap();
        }
    }
}