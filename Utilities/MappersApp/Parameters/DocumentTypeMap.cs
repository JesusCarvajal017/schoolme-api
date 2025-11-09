using AutoMapper;
using Entity.Dtos.Parameters.DocumentType;
using Entity.Model.Paramters;

namespace Utilities.MappersApp.Parameters
{
    public class DataBasicMap : Profile
    {
        public DataBasicMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
        }
    }
}