using AutoMapper;
using Entity.Dtos.Parameters.Grade;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class GradeMap : Profile
    {
        public GradeMap()
        {
            CreateMap<Grade, GradeDto>().ReverseMap();
        }
    }
}