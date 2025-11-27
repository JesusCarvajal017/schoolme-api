using Entity.Model.Business;

namespace Data.Interfaces.Group.Commands
{
    public interface ICommandStudentAnswar : ICommands<StudentAnswer>
    {
        Task RegisterAnswersAsync(IEnumerable<StudentAnswer> answers, CancellationToken ct = default);

        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
