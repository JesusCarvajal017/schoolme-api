
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

    }
}
