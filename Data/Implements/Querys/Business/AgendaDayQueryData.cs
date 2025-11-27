using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
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

     
      
        //public virtual async Task<AgendaDay> 



    }
}
