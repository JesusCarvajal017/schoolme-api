
using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Commands.Business
{
    public class AgendaDayCommandData : BaseGenericCommandsData<AgendaDay>, ICommanAgendaDay
    {
        protected readonly ILogger<AgendaDayCommandData> _logger;
        protected readonly AplicationDbContext _context;

        public AgendaDayCommandData(AplicationDbContext context, ILogger<AgendaDayCommandData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
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
        }
    }


}
