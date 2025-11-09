using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysStudent : IQuerys<Student>
    {
        Task<IEnumerable<Student>> QueryRelations(int? status,int personId);
    }
}