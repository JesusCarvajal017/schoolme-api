using Entity.Dtos.Especific;
using Entity.Dtos.Especific.Security;
using Entity.Model.Security;

namespace Data.Interfaces.Group.Commands
{
    public interface ICommandUser : ICommands<User>
    {

        //Task<bool> InsertFormDataAsync(ChangePassword current);
        Task<bool> UpdatePassword(ChangePassword current);
        Task<bool> UpdatePhoto(ChangePhoto current);


    }
}
