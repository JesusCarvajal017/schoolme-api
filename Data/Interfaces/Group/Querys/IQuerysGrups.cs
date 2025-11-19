using Entity.Model.Business;
using Entity.Model.Paramters;
using Entity.Model.Security;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysGrups : IQuerys<Groups>
    {
        Task<IEnumerable<Groups>> QueryGrupsGrade(int gradeId);
    }
}