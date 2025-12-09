using Entity.Dtos.Business.AgendaDay;

namespace Business.Interfaces.SingalR
{
    public interface IAgendaDayRealtimeService
    {
        Task PublishTodayListAsync(CancellationToken ct = default);
    }
}
