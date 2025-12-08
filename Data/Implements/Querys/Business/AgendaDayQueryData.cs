using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class AgendaDayQueryData : BaseGenericQuerysData<AgendaDay> , IQuerysAgendaDay
    {
        protected readonly ILogger<AgendaDayQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public AgendaDayQueryData(AplicationDbContext context, ILogger<AgendaDayQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<AgendaDay>> GetByDateAsync(
            DateOnly date,
            CancellationToken ct = default)
        {
            return await _dbSet
                .Where(a =>
                    a.Date == date &&
                    a.Status == 1)                  
                .Include(a => a.Agenda)
                .Include(a => a.Group)
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }
}
