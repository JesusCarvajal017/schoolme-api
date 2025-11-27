using Entity.Model.Business;
using Entity.Model.Paramters;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysGroupDirector : IQuerys<GroupDirector>
    {
        Task<IEnumerable<GroupDirector>> GroupsDirector(int teacherId);
    }
}