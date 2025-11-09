using Entity.Context.Main;
using Entity.Model.Business;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class TutitionQueryData : BaseGenericQuerysData<Tutition>
    {
        protected readonly ILogger<TutitionQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public TutitionQueryData(AplicationDbContext context, ILogger<TutitionQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<Tutition>> QueryAllAsyn(int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<Tutition> query = _dbSet.
                                                AsQueryable()
                                                .Include(p => p.Student)
                                                    .ThenInclude(P => P.Person)

                                                .Include(q => q.Grade);


                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Tutition).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Tutition).Name);
                throw;
            }
        }


    
  


    }
}
