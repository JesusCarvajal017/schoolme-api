using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Business
{
    public class AgendaDayStudentQueryData : BaseGenericQuerysData<AgendaDayStudent> , IQuerysAgendaDayStudent
    {
        protected readonly ILogger<AgendaDayStudentQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public AgendaDayStudentQueryData(AplicationDbContext context, ILogger<AgendaDayStudentQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }



        //public virtual async Task<AgendaDay> 


        public async Task<List<AgendaDayStudentListItem>> StudentsByAgendaDayAsync(int agendaDayId,
        CancellationToken ct = default)
        {
            return await _dbSet
                .Where(x => x.AgendaDayId == agendaDayId)
                .Include(x => x.Student)
                    .ThenInclude(s => s.Person)
                        .ThenInclude(s => s.DocumentType)

                .Select(x => new AgendaDayStudentListItem
                {
                    AgendaDayStudentId = x.Id,
                    StudentId = x.StudentId,
                    FullName = x.Student.Person.FisrtName + " " + x.Student.Person.LastName,
                    Document = x.Student.Person.Identification,
                    TypeDocumetation = x.Student.Person.DocumentType.Acronym,
                    AgendaId = x.AgendaDay.AgendaId,

                })
                .AsNoTracking()
                .ToListAsync(ct);
        }

        // metodo que consulta si la agenda del estudiante ya esta disponible para poder confirmala
        public async Task<List<AgendaDayStudent>> GetPendingConfirmationsByStudentAsync(
        int studentId,
        DateOnly date,
        CancellationToken ct = default)
        {
            return await _dbSet
                .Where(x =>
                    x.StudentId == studentId &&
                    x.Status == 1 &&                       // activo

                    // aquí pones el estado que signifique "pendiente de confirmación"
                    x.AgendaDayStudentStatus == 1 &&
                    x.AgendaDay.Date == date &&
                    x.AgendaDay.ClosedAt != null)          // agenda cerrada
                .Include(x => x.AgendaDay)
                    .ThenInclude(ad => ad.Agenda)
                .Include(x => x.AgendaDay)
                    .ThenInclude(ad => ad.Group)
                .AsNoTracking()
                .ToListAsync(ct);
        }


    }


}
