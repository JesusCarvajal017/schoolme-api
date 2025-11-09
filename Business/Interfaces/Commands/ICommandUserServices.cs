using Business.Interfaces.Commands;
using Entity.Dtos.Especific;
using Entity.Dtos.Especific.Security;
using Entity.Dtos.Security.User;
using Entity.Model.Security;

namespace Business.Interfaces.Querys
{
    public interface ICommandUserServices : ICommandService<User, UserDto>
    {
        Task<UserDto> CreateRemastered(UserCreateDto current);
        Task<bool> ChangePasswordServices(ChangePassword current);
        Task<bool> ChangePhotoServices(ChangePhotoDto current);
    }
}
