using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Entity.Model.Paramters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class AcademimcLoadQueryData : BaseGenericQuerysData<AcademicLoad> , IQuerysAcademicLoad
    {
        protected readonly ILogger<AcademimcLoadQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public AcademimcLoadQueryData(AplicationDbContext context, ILogger<AcademimcLoadQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<IEnumerable<AcademicLoad>> QueryAllAsyn(int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<AcademicLoad> query = _dbSet.
                                                AsQueryable()
                                                .Include(p => p.Teacher)
                                                    .ThenInclude(d => d.Person)
                                                .Include(p => p.Subject)
                                                .Include(p => p.Group);


                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Munisipality).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Munisipality).Name);
                throw;
            }
        }


        public virtual async Task<IEnumerable<AcademicLoad>> QueryCargaAcademica(int idTeacher, int? status)
        {
            try
            {
                // El as queryable me permite ir construyendo la consulta
                IQueryable<AcademicLoad> query = _dbSet.
                                                AsQueryable()
                                                .Include(p => p.Teacher)
                                                    .ThenInclude(d => d.Person)
                                                .Include(p => p.Group)
                                                .Include(p => p.Subject)
                                                .Where(a => a.TeacherId == idTeacher);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Munisipality).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Munisipality).Name);
                throw;
            }

        }






    }
}
