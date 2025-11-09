using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class StudentQueryData : BaseGenericQuerysData<Student> 
    {
        protected readonly ILogger<StudentQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public StudentQueryData(AplicationDbContext context, ILogger<StudentQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<Student>> QueryAllAsyn(int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<Student> query = _dbSet.
                                                AsQueryable()
                                                .Include(p => p.Person)
                                                    .ThenInclude(P => P.DocumentType)
                                                 .Include(g => g.Groups);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Student).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Student).Name);
                throw;
            }
        }


        public override async Task<Student?> QueryById(int id)
        {

            try
            {
                var query = await _dbSet
                  .AsNoTracking()
                  .Include(p => p.Person)
                    .ThenInclude(P => P.DocumentType)
                  .FirstOrDefaultAsync(e => e.Id == id); ;

                return query;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(Student).Name);
                return null;
            }

        }
    }
}
