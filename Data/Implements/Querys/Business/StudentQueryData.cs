using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class StudentQueryData : BaseGenericQuerysData<Student> , IQuerysStudent
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

        public virtual async Task<Student> QueryCompleteData(int studentId)
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
                 .FirstOrDefaultAsync(p => p.Id == studentId);

                return query;

            }
            catch (Exception ex)
            {

                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Student).Name);
                return new Student();
            }
        }

        public virtual async Task<IEnumerable<Student>> QueryMatriculados()
        {
            try
            {
                var studentsSinMatricula = await _context.Students
                    .Where(s => s.Tutition.Count() == 0)
                    .Include(p => p.Person)
                        .ThenInclude(P => P.DocumentType)
                    .ToListAsync();

                return studentsSinMatricula;
            }catch(Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta de los no matriculados {Entity}", typeof(Student).Name);
                return [];
            }


        }


        public virtual async Task<IEnumerable<Student>> QueryStudentsGroup(int groupId)
        {
            try
            {
                var studentsSinMatricula = await _context.Students
                    .Where(s => s.GroupId == groupId)
                    .Include(p => p.Person)
                        .ThenInclude(P => P.DocumentType)
                    .ToListAsync();

                return studentsSinMatricula;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta de los no matriculados {Entity}", typeof(Student).Name);
                return [];
            }


        }
    }
}
