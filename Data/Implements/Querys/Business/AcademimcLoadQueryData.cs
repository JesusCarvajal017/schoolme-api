using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Enum;
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


        // consulta de carga academica para un docente
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

        // Consulta de carga academica de un docente con filtro de dia 
        public virtual async Task<IEnumerable<AcademicLoad>> LoadTeacherDay(
            int idTeacher,
            int? status,
            int? day // NUEVO
        )
        {
            try
            {
                IQueryable<AcademicLoad> query = _dbSet
                    .AsQueryable()
                    .Include(p => p.Teacher)
                        .ThenInclude(d => d.Person)
                    .Include(p => p.Group)
                    .Include(p => p.Subject)
                    .Where(a => a.TeacherId == idTeacher);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                if (day.HasValue)
                {
                    var dayMask = day.Value; // ej: 1=Lunes, 2=Martes, 4=Miércoles, etc.

                    query = query.Where(a =>
                        a.Days.HasValue &&           // que tenga algo
                        (a.Days.Value & dayMask) == dayMask // bitwise AND
                    );
                }

                var model = await query.ToListAsync();

                _logger.LogInformation("Consulta de la entidad {Entity} se realizó exitosamente", typeof(AcademicLoad).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en la consulta la entidad {Entity}", typeof(AcademicLoad).Name);
                throw;
            }
        }

        // Consulta la materias que dicta en el dia para su observacion
        public async Task<List<AcademicLoad>> GetLoadsByTeacherAndDayAsync(int teacherId,Days day, CancellationToken ct = default)
        {
            return await _dbSet
                .Where(a => a.TeacherId == teacherId
                            && a.Days.HasValue
                            && ((Days)a.Days.Value).HasFlag(day))
                .Include(a => a.Subject)
                .Include(a => a.Group)
                    .ThenInclude(g => g.Grade)
                .Include(a => a.Group)
                    .ThenInclude(g => g.AgendaDay)   
                .AsNoTracking()
                .ToListAsync(ct);
        }









    }
}
