using AutoMapper;
using Entity.Dtos.Business.DataBasic;
using Entity.Dtos.Especific.DataBasicComplete;
using Entity.Dtos.Security.Person;
using Entity.Enum;
using Entity.Model.Business;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class PersonMap : Profile
    {
        public PersonMap()
        {
            // Mapeo de Rol a RolDto y viceversa
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<Person, PersonQueryDto>()
                .ForMember(dest => dest.AcronymDocument, opt => opt.MapFrom(p => p.DocumentType.Acronym));

            // configuracion de data completa de persona
            CreateMap<Person, CompleteDataPersonDto>()
                // Básicos de Person
                .ForMember(d => d.DocumentTypeId, o => o.MapFrom(s => s.DocumentTypeId))
                .ForMember(d => d.Identification, o => o.MapFrom(s => s.Identification))
                .ForMember(d => d.FisrtName, o => o.MapFrom(s => s.FisrtName))
                .ForMember(d => d.SecondName, o => o.MapFrom(s => s.SecondName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.SecondLastName, o => o.MapFrom(s => s.SecondLastName))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.Phone))
                .ForMember(d => d.Gender, o => o.MapFrom(s => (GenderEmun?)s.Gender))

                // DocumentType
                .ForMember(d => d.AcronymDocument, o => o.MapFrom(s => s.DocumentType != null ? s.DocumentType.Acronym : null))

                // DataBasic directos
                .ForMember(d => d.RhId, o => o.MapFrom(s => s.DataBasic != null ? (int?)s.DataBasic.RhId : null))
                .ForMember(d => d.Adress, o => o.MapFrom(s => s.DataBasic != null ? s.DataBasic.Adress : null))
                .ForMember(d => d.BrithDate, o => o.MapFrom(s => s.DataBasic != null ? s.DataBasic.BrithDate.ToString("yyyy-MM-dd") : null))
                .ForMember(d => d.StratumStatus, o => o.MapFrom(s => s.DataBasic != null ? (int?)s.DataBasic.StratumStatus : null))
                .ForMember(d => d.MaterialStatusId, o => o.MapFrom(s => s.DataBasic != null ? (int?)s.DataBasic.MaterialStatusId : null))
                .ForMember(d => d.EpsId, o => o.MapFrom(s => s.DataBasic != null ? (int?)s.DataBasic.EpsId : null))
                .ForMember(d => d.MunisipalityId, o => o.MapFrom(s => s.DataBasic != null ? (int?)s.DataBasic.MunisipalityId : null))

                // DataBasic navegaciones
                .ForMember(d => d.RhName, o => o.MapFrom(s => s.DataBasic != null && s.DataBasic.Rh != null ? s.DataBasic.Rh.Name : null))
                .ForMember(d => d.EpsName, o => o.MapFrom(s => s.DataBasic != null && s.DataBasic.Eps != null ? s.DataBasic.Eps.Name : null))
                .ForMember(d => d.MunisipalityName, o => o.MapFrom(s => s.DataBasic != null && s.DataBasic.Munisipality != null ? s.DataBasic.Munisipality.Name : null))

                // Por si tu ABaseDto tiene más props y no quieres mapearlas automáticamente:
                //.ForAllOtherMembers(o => o.Ignore())
                ;


            CreateMap<PersonCompleteDto, Person>()
               .ForMember(d => d.Id, o => o.Ignore())     // PK la genera la 
               .ForMember(d => d.DataBasic, o => o.MapFrom(s => s.DataBasic))
               // Importante para UPDATE parcial: no sobrescribir con nulls
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // DataBasicDto -> DataBasic
            CreateMap<DataBasicDto, DataBasic>()
                .ForMember(d => d.Id, o => o.Ignore())       // PK propia
                .ForMember(d => d.PersonId, o => o.Ignore())
                 
                // EF lo fija por navegación en create
                // No sobrescribir con nulls (útil para updates parciales)
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));



            CreateMap<Person, PersonCompleteDto>()
               .ForMember(d => d.DataBasic, o => o.MapFrom(s => s.DataBasic));

            CreateMap<DataBasic, DataBasicDto>()
                .ForMember(d => d.PersonId, o => o.MapFrom(s => s.PersonId));


            // ==================================
            // ENTITY -> DTO (Read) configuration 
            // ==================================

            CreateMap<Person, PersonCompleteReadDto>()
                .ForMember(d => d.DataBasic, o => o.MapFrom(s => s.DataBasic));

            CreateMap<DataBasic, DataBasicReadDto>()
                .ForMember(d => d.PersonId, o => o.MapFrom(s => s.PersonId))
                .ForMember(d => d.DepartamentId, o => o.MapFrom(s => s.Munisipality.Departament.Id));



        }
    }
}