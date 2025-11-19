using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Entity.Model.Paramters;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class TeacherQueryData : BaseGenericQuerysData<Teacher> , IQueryTeacher
    {
        protected readonly ILogger<TeacherQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public TeacherQueryData(AplicationDbContext context, ILogger<TeacherQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<Teacher>> QueryAllAsyn(int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<Teacher> query = _dbSet.
                        AsQueryable()
                        .Include(p => p.Person)
                            .ThenInclude(P => P.DocumentType);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Teacher).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Teacher).Name);
                throw;
            }
        }


        public override async Task<Teacher?> QueryById(int id)
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
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(Teacher).Name);
                return null;
            }

        }

        public virtual async Task<Teacher> QueryCompleteData(int teacherId)
        {
            try
            {
                var query = await _dbSet
                 .AsNoTracking()
                 .Include(p => p.Person)
                     .ThenInclude(p => p.DocumentType)

                 .Include(p => p.Person)
                     .ThenInclude(p => p.DataBasic)
                        .ThenInclude(d => d.Rh)

                 .Include(p => p.Person)
                     .ThenInclude(p => p.DataBasic)
                         .ThenInclude(d => d.Eps)

                  .Include(p => p.Person)
                         .ThenInclude(d => d.DataBasic)
                            .ThenInclude(d => d.Munisipality)
                                .ThenInclude(m => m.Departament)
                    .Include(p => p.Person)
                         .ThenInclude(p => p.DataBasic)
                             .ThenInclude(d => d.MaterialStatus)
                 .AsSplitQuery()
                 .FirstOrDefaultAsync(p => p.Id == teacherId);

                return query;

            }
            catch (Exception ex)
            {

                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Teacher).Name);
                return new Teacher();
            }
        }





    }
}
