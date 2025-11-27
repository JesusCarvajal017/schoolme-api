using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{
    public interface IQueryStudentAsware : IQuerys<StudentAnswer>
    {
        Task<List<StudentAnswer>> GetAnswersByAgendaDayStudentAsync(int agendaDayStudentId, CancellationToken ct = default);
    }
}
