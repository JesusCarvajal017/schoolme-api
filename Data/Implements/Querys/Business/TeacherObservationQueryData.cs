using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class TeacherObservationQueryData : BaseGenericQuerysData<TeacherObservation>, IQueryTeacherObservation
    {
        protected readonly ILogger<TeacherObservationQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public TeacherObservationQueryData(AplicationDbContext context, ILogger<TeacherObservationQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<TeacherObservation?> QueryObservationStudent(int agendaStudentDayId, int academicLoadId, CancellationToken ct = default)
        {
            try
            {
                return await _dbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e =>
                        e.AgendaDayStudentId == agendaStudentDayId &&
                        e.AcademicLoadId == academicLoadId, 
                        ct);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(TeacherObservation).Name);
                return null;
            }

        }

        public async Task<List<TeacherObservation>> GetByAgendaDayStudentAsync(int agendaDayStudentId, CancellationToken ct = default)
        {
            return await _dbSet
                .Where(o => o.AgendaDayStudentId == agendaDayStudentId)
                .Include(o => o.Teacher)
                    .ThenInclude(t => t.Person)
                .Include(o => o.AgendaDayStudent)
                    .ThenInclude(ads => ads.AgendaDay)
                        .ThenInclude(ad => ad.Group)
                            .ThenInclude(g => g.Grade)
                .Include(o => o.AcademicLoad)              
                    .ThenInclude(al => al.Subject)       
                .AsNoTracking()
                .ToListAsync(ct);
        }
    }
}
