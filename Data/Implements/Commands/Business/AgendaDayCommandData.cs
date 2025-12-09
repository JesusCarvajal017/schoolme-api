
using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.SignalR.Interfaces;

namespace Data.Implements.Commands.Business
{
    public class AgendaDayCommandData : BaseGenericCommandsData<AgendaDay>, ICommanAgendaDay
    {
        protected readonly ILogger<AgendaDayCommandData> _logger;
        protected readonly AplicationDbContext _context;
        private readonly INotificationsService _notifications;

        public AgendaDayCommandData(AplicationDbContext context, ILogger<AgendaDayCommandData> logger, INotificationsService notifi) : base(context, logger)
        {
            _context = context;
            _logger = logger;
            _notifications = notifi;
        }

        public async Task<AgendaDay?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet
                .FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            await _context.SaveChangesAsync(ct);
        }

        public async Task ReopenAgendaDayAsync(int agendaDayId, CancellationToken ct = default)
        {
            var agendaDay = await _context.AgendaDay
            .Include(ad => ad.AgendaDayStudents)
            .Include(ad => ad.Group)
                .ThenInclude(g => g.GroupDirector)
                    .ThenInclude(gd => gd.Teacher)
            .FirstOrDefaultAsync(ad => ad.Id == agendaDayId, ct);

            if (agendaDay is null)
            {
                _logger.LogWarning("No se encontró AgendaDay con Id {AgendaDayId} para reabrir.", agendaDayId);
                return;
            }

            // Solo tiene sentido reabrir si estaba cerrada
            if (agendaDay.ClosedAt == null)
            {
                _logger.LogInformation("AgendaDay {AgendaDayId} ya se encuentra abierta.", agendaDayId);
                return;
            }

            agendaDay.ClosedAt = null;
            agendaDay.UpdatedAt = DateTime.UtcNow;

            foreach (var ads in agendaDay.AgendaDayStudents)
            {
                ads.Status = 1;
                ads.UpdatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync(ct);

            _logger.LogInformation(
                "AgendaDay {AgendaDayId} fue reabierta y se resetearon {Count} AgendaDayStudent.",
                agendaDayId,
                agendaDay.AgendaDayStudents.Count);

            // ==== 🔔 ENVIAR NOTIFICACIÓN AL DIRECTOR ====

            var directorPersonId = agendaDay.Group?
                .GroupDirector?
                .Teacher?
                .PersonId;

            _logger.LogInformation(
                "PersonId director para AgendaDay {AgendaDayId}: {PersonId}",
                agendaDayId,
                directorPersonId
            );

            if (directorPersonId.HasValue)
            {
                var user = await _context.User
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.PersonId == directorPersonId.Value, ct);

                if (user != null)
                {
                    var userId = user.Id.ToString();

                    _logger.LogInformation("Enviando notificación de reapertura a userId {UserId}", userId);

                    await _notifications.SendAsync(
                        userId,
                        "Agenda reabierta",
                        $"La agenda del grupo {agendaDay.Group!.Name} fue reabierta.",
                        "info",
                        new
                        {
                            agendaDayId = agendaDay.Id,
                            agendaDay.AgendaId,
                            agendaDay.GroupId
                        },
                        ct
                    );
                }
                else
                {
                    _logger.LogWarning(
                        "No se encontró User para PersonId {PersonId} al reabrir AgendaDay {AgendaDayId}",
                        directorPersonId.Value, agendaDayId);
                }
            }
            else
            {
                _logger.LogWarning(
                    "El grupo {GroupId} no tiene GroupDirector/Teacher asociado al reabrir AgendaDay {AgendaDayId}",
                    agendaDay.GroupId, agendaDayId);
            }

        }
    }

}
