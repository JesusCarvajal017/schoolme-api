using AutoMapper;
using Entity.Dtos.Especific;
using Entity.Dtos.Security.User;
using Entity.Model.Security;

namespace Utilities.MappersApp.security
{
    public class UserMap : Profile
    {
        public UserMap() 
        {
            // map de commandos
            CreateMap<User, UserDto>()
                .ForMember(x => x.Photo, op => op.Ignore())
                //.ForMember(dest=> dest.PersonId, opt => opt.MapFrom(d => Convert.ToInt32(d.PersonId)))
                //.ForMember(dest => dest.Status, opt => opt.MapFrom(d => Convert.ToInt32(d.Status)))
                .ReverseMap();


            // remastered
            CreateMap<User, UserCreateDto>()
                .ForMember(x => x.Photo, op => op.Ignore())
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(d => Convert.ToInt32(d.PersonId)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(d => Convert.ToInt32(d.Status)))
                .ReverseMap();

            // consulta principal
            CreateMap<User, UserQueryDto>().ReverseMap();


            CreateMap<ChangePhoto, ChangePhotoDto>()
                .ForMember(x => x.Photo, op => op.Ignore()).ReverseMap();



        }
    }
}
