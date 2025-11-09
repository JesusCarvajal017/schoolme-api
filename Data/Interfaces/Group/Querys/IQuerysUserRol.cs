using Data.Interfaces.Basic;
using Entity.Model.Global;
using Entity.Model.Security;
using Microsoft.AspNetCore.Identity;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysUserRol : IQuerys<UserRol>
    {
        Task<IEnumerable<UserRol>> QueryUserRol(int UserId);
    }
}