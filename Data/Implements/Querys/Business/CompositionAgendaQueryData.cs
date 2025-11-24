using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class CompositionAgendaQueryData : BaseGenericQuerysData<CompositionAgendaQuestion>, IQueryCompositionAgenda
    {
        protected readonly ILogger<CompositionAgendaQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public CompositionAgendaQueryData(AplicationDbContext context, ILogger<CompositionAgendaQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

    

        public async Task<IEnumerable<CompositionAgendaQuestion>> QuerAgendaComposite(int agendaId)
        {
            try
            {
                var studentsTutition = await _context.CompositionAgendaQuestion
                                    .Where(c => c.AgendaId == agendaId)
                                    .Include(g => g.Question)
                                        .ThenInclude(q => q.TypeAswer)
                                    .ToListAsync();

                return studentsTutition;

            } 
            catch (Exception ex) {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(CompositionAgendaQuestion).Name);
                throw;

            }
            
        }
    
  


    }
}
