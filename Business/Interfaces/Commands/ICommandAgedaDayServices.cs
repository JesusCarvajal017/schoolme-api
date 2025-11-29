using Business.Interfaces.Commands;
using Entity.Dtos.Business.AgendaDay;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface ICommandAgedaDayServices : ICommandService<AgendaDay, AgendaDayDto>
    {
        Task CloseAsync(int agendaDayId, CancellationToken ct = default);
    }
}
