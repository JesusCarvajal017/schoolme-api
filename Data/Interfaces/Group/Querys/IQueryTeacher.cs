using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{
    public interface IQueryTeacher : IQuerys<Teacher>
    {
        Task<Teacher> QueryCompleteData(int personId);
    }
}
