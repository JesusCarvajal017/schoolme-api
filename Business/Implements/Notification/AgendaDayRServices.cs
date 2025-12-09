using Business.Interfaces.Querys;
using Business.Interfaces.SingalR;
using Microsoft.AspNetCore.SignalR;
using Utilities.SignalR.Implements;

namespace Business.Implements.Notification
{
    public class AgendaDayRealtimeService : IAgendaDayRealtimeService
    {
        private readonly IHubContext<NotificationHub> _hub;
        private readonly IQueryAgendaDayServices _queryAgendaDay;

        public AgendaDayRealtimeService(IHubContext<NotificationHub> hub, IQueryAgendaDayServices queryAgendaDay)
        {
            _hub = hub;
            _queryAgendaDay = queryAgendaDay;
        }

        public async Task PublishTodayListAsync(CancellationToken ct = default)
        {
            // 👇 REUTILIZAMOS TU MÉTODO DE BUSINESS
            var list = await _queryAgendaDay.GetTodayAgendaDaysAsync(ct);

            // enviamos a todos los clientes que estén conectados
            await _hub.Clients.All.SendAsync("agendaDayTodayList", list, ct);
        }
    }
}
