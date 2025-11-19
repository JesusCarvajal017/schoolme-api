using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class TutitionQueryData : BaseGenericQuerysData<Tutition>, IQuerysTutition
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



        public async Task<IEnumerable<Tutition>> QueryTutitionGrade(int gradeId)
        {
            var studentsTutition = await _context.Tutition
                                    .Where(t=> t.GradeId == gradeId && t.Status == 1)

                                     .Include(p => p.Student)
                                                    .ThenInclude(P => P.Person)
                                                .Include(q => q.Grade)
                                    .ToListAsync();

            return studentsTutition;

        }
    
  


    }
}
