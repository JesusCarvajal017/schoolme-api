using Entity.Model.Business;

namespace Data.Interfaces.Group.Commands
{
    public interface ICommanAgendaDay : ICommands<AgendaDay>
    {
        Task<AgendaDay?> GetByIdAsync(int id, CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
