using AutoMapper;
using Entity.Dtos.Business.DataBasic;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class DataBasicMap : Profile
    {
        public DataBasicMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<DataBasic, DataBasicDto>().ReverseMap();
        }
    }
}