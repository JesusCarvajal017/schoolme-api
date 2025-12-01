using Entity.Model.Business;

namespace Data.Interfaces.Group.Commands
{
    public interface ICommandStudentAnswar : ICommands<StudentAnswer>
    {
        Task RegisterAnswersAsync(IEnumerable<StudentAnswer> answers, CancellationToken ct = default);

        Task SaveChangesAsync(CancellationToken ct = default);

        Task<List<StudentAnswer>> GetTrackedByAgendaDayStudentAsync(
            int agendaDayStudentId, CancellationToken ct = default);


        void Add(StudentAnswer answer);
    }
}
