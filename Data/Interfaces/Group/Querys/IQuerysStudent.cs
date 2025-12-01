using Entity.Model.Business;
using Entity.Model.Security;
using MimeKit.Tnef;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysStudent : IQuerys<Student>
    {
        //Task<IEnumerable<Student>> QueryRelations(int? status,int personId);
        Task<Student> QueryCompleteData(int studentId);

        Task<IEnumerable<Student>> QueryMatriculados();


        Task<IEnumerable<Student>> QueryStudentsGroup(int groupId);


    }
}