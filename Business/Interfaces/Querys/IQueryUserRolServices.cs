using Entity.Dtos.Security.UserRol;
using Entity.Model.Security;

namespace Business.Interfaces.Querys
{
    public interface IQueryUserRolServices : IQueryServices<UserRol, UserRolDto>
    {
        Task<IEnumerable<UserRolDto>> GetRolsUserServices(int IdUser);
    }
}
