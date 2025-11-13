using Entity.Model.Business;
using Entity.Model.Security;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysAttendas : IQuerys<Attendants>
    {
        Task<IEnumerable<Attendants>> QueryRelations(int? status,int personId);
        Task<IEnumerable<Attendants>> QueryRelationsStudents(int? status,int personId);

        Task<Attendants> QueryCompleteData(int personId);
    }
}