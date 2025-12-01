using Entity.Model.Business;
using Entity.Model.Security;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de matricula
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysTutition : IQuerys<Tutition>
    {
        Task<IEnumerable<Tutition>> QueryTutitionGrade(int gradeId);
    }
}