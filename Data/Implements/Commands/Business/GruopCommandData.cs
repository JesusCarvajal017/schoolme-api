using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Model.Paramters;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Commands.Business
{
    public class GruopCommandData : BaseGenericCommandsData<Groups>, ICommadGroups
    {
        protected readonly ILogger<GruopCommandData> _logger;
        protected readonly AplicationDbContext _context;

        public GruopCommandData(AplicationDbContext context, ILogger<GruopCommandData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> UpdateAgendaAsync(int id, int? agendaId)
        {
            var entity = await _context.Set<Groups>().FindAsync(id);
            if (entity == null)
                return false;

            entity.AgendaId = agendaId; 

            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
