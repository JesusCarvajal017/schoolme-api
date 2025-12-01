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

        public async Task<TeacherObservation> QueryObservationStudent(int agendaStudentDayId)
        {
            try
            {
                var query = await _dbSet
                  .AsNoTracking()
                  .FirstOrDefaultAsync(e => e.AgendaDayStudentId == agendaStudentDayId); ;

                return query;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta con id {id}", typeof(TeacherObservation).Name);
                return null;
            }

        }
    }
}
