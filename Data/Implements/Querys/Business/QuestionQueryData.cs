using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class QuestionQueryData : BaseGenericQuerysData<Question>
    {
        protected readonly ILogger<QuestionQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public QuestionQueryData(AplicationDbContext context, ILogger<QuestionQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<Question>> QueryAllAsyn(int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<Question> query = _dbSet.
                                                AsQueryable()
                                                .Include(p => p.TypeAswer);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Question).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Question).Name);
                throw;
            }
        }

        public override async Task<Question?> QueryById(int id)
        {

            try
            {
                var query = await _dbSet
                  .AsNoTracking()
                  .Include(q => q.QuestionOptions)
                   .FirstOrDefaultAsync(q => q.Id == id);

                return query;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(Question).Name);
                return null;
            }

        }






    }
}
