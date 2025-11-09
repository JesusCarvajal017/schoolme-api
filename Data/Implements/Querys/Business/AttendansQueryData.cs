using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class AttendansQueryData : BaseGenericQuerysData<Attendants>, IQuerysAttendas
    {
        protected readonly ILogger<AttendansQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public AttendansQueryData(AplicationDbContext context, ILogger<AttendansQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }



        // <summary>
        //  Consulta general de toda la pivote
        // </summary>
        public override async Task<IEnumerable<Attendants>> QueryAllAsyn(int? status)
        {
            try
            {
                IQueryable<Attendants> baseQuery = _dbSet.AsNoTracking();

                if (status.HasValue)
                    baseQuery = baseQuery.Where(x => x.Status == status.Value);

                // Id mínimo por persona (una fila por PersonId)
                var idsUnicos = baseQuery
                    .GroupBy(a => a.PersonId)
                    .Select(g => g.Min(a => a.Id));

                // Trae esas filas (join por Id), incluye navegación y ordena por Id asc
                var model = await _dbSet
                    .AsNoTracking()
                    .Where(a => idsUnicos.Contains(a.Id))
                    .Include(a => a.Person)
                        .ThenInclude(p => p.DocumentType)
                    .OrderBy(a => a.Id)
                    .ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Attendants).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Attendants).Name);
                throw;
            }
        }


        // <summary>
        //  Consulta los vinculos que tiene el acudiente
        // </summary>

        public virtual async Task<IEnumerable<Attendants>> QueryRelations(int? status, int personId)
        {
            try
            {

                IQueryable<Attendants> query = _dbSet
                .AsNoTracking()
                .Where(e => e.PersonId == personId);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query
                    .OrderBy(x => x.Id)
                    .Include(a => a.Person)
                        .ThenInclude(p => p.DocumentType)
                    .Include(a => a.Student)
                        .ThenInclude(s => s.Person)
                            .ThenInclude(p => p.DocumentType)
                    .ToListAsync();


                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Attendants).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Attendants).Name);
                throw;
            }

        }


        // <summary>
        //  Consulta los acudientes que tiene el estudiante
        // </summary>
        public virtual async Task<IEnumerable<Attendants>> QueryRelationsStudents(int? status, int studentId)
        {
            try
            {
                IQueryable<Attendants> query = _dbSet
                .AsNoTracking()
                .Where(e => e.StudentId == studentId);

                if (status.HasValue)
                    query = query.Where(x => x.Status == status.Value);

                var model = await query
                    .OrderBy(x => x.Id)
                    .Include(a => a.Person)
                        .ThenInclude(p => p.DocumentType)
                     .Include(a => a.Student)
                        .ThenInclude(s => s.Person)
                            .ThenInclude(p => p.DocumentType)
                    .ToListAsync();


                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Attendants).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Attendants).Name);
                throw;
            }

        }

        public override async Task<Attendants?> QueryById(int id)
        {

            try
            {
                var query = await _dbSet
                  .AsNoTracking()
                  .Include(p => p.Person)
                  .FirstOrDefaultAsync(e => e.Id == id); ;

                return query;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(Attendants).Name);
                return null;
            }

        }






    }
}
