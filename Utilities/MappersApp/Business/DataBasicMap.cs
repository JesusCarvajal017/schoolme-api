using AutoMapper;
using Entity.Dtos.Business.DataBasic;
using Entity.Model.Business;

namespace Utilities.MappersApp.Business
{
    public class DataBasicMap : Profile
    {
        public DataBasicMap()
        {
            // Entity -> DTO
            CreateMap<DataBasic, DataBasicDto>()
                .ForMember(d => d.RhId, o => o.MapFrom(s => s.RhId))
                .ForMember(d => d.EpsId, o => o.MapFrom(s => s.EpsId))
                .ForMember(d => d.MaterialStatusId, o => o.MapFrom(s => s.MaterialStatusId))
                .ForMember(d => d.MunisipalityId, o => o.MapFrom(s => s.MunisipalityId))
                // DepartamentId solo para salida (puede ser null si la nav no está cargada)
                .ForMember(d => d.DepartamentId,
                    o => o.MapFrom(s => s.Munisipality != null ? (int?)s.Munisipality.DepartamentId : null));

            // DTO -> Entity
            CreateMap<DataBasicDto, DataBasic>()
             .ForMember(e => e.Id, o => o.Ignore())
             .ForMember(e => e.PersonId, o => o.Ignore())

             .ForMember(e => e.RhId, o => { o.PreCondition(d => d.RhId.HasValue); o.MapFrom(d => d.RhId!.Value); })
             .ForMember(e => e.EpsId, o => { o.PreCondition(d => d.EpsId.HasValue); o.MapFrom(d => d.EpsId!.Value); })
             .ForMember(e => e.MaterialStatusId, o => { o.PreCondition(d => d.MaterialStatusId.HasValue); o.MapFrom(d => d.MaterialStatusId!.Value); })
             .ForMember(e => e.MunisipalityId, o => { o.PreCondition(d => d.MunisipalityId.HasValue); o.MapFrom(d => d.MunisipalityId!.Value); })

             // Nunca llenar navegaciones desde el DTO (evita inserts accidentales)
             .ForMember(e => e.Munisipality, o => o.Ignore())
             .ForMember(e => e.Rh, o => o.Ignore())
             .ForMember(e => e.Eps, o => o.Ignore())
             .ForMember(e => e.MaterialStatus, o => o.Ignore())

             // Campos simples (solo si vienen)
             .ForMember(e => e.Adress, o => o.PreCondition(d => d.Adress != null))
             .ForMember(e => e.BrithDate, o => o.PreCondition(d => d.BrithDate.HasValue))
             .ForMember(e => e.StratumStatus, o => o.PreCondition(d => d.StratumStatus.HasValue));

        }
    }
}