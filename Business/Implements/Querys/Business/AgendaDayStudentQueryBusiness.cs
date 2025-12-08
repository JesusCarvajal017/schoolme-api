using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;
using static Business.Implements.Querys.Business.AgendaDayStudentQueryBusiness;

namespace Business.Implements.Querys.Business
{
    public class AgendaDayStudentQueryBusiness : BaseQueryBusiness<AgendaDayStudent, AgendaDayStudentDto>, IQueryAgendaStudentDayServices
    {
        protected readonly IQuerysAgendaDayStudent _data;

        private readonly AplicationDbContext _context;

        public AgendaDayStudentQueryBusiness(
            IQuerysAgendaDayStudent data,
            IMapper mapper,
            ILogger<AgendaDayStudentQueryBusiness> _logger,
            AplicationDbContext context,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
            _context = context;
        }

        public async Task<List<AgendaDayStudentListDto>> GetStudentsByAgendaDayAsync(
        int agendaDayId,
        CancellationToken ct = default)
        {
            var items = await _data.StudentsByAgendaDayAsync(agendaDayId, ct);
            return _mapper.Map<List<AgendaDayStudentListDto>>(items);
        }

        // Metodo de logica de engocio si tiene para confirmar
        public async Task<List<AgendaConfirmationQueryDto>> GetPendingConfirmationsByStudentAsync(
            int studentId,
            CancellationToken ct = default)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            var entities = await _data.GetPendingConfirmationsByStudentAsync(studentId, today, ct);

            var dtos = _mapper.Map<List<AgendaConfirmationQueryDto>>(entities);

            return dtos;
        }



        public async Task SyncAgendaDayStudentsAsync(int agendaDayId, CancellationToken ct = default)
        {
            // 1️⃣ Cargar la AgendaDay para obtener el GroupId
            var agendaDay = await _context.AgendaDay
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == agendaDayId, ct);

            if (agendaDay is null)
            {
                _logger.LogWarning("No se encontró AgendaDay con Id {AgendaDayId}.", agendaDayId);
                return;
            }

            var groupId = agendaDay.GroupId;

            // 2️⃣ Obtener estudiantes actuales del grupo
            var currentStudentIds = await _context.Students
                .Where(s => s.GroupId == groupId && s.Status == 1)
                .Select(s => s.Id)
                .ToListAsync(ct);

            var now = DateTime.UtcNow;

            // 3️⃣ Obtener todos los AgendaDayStudent de esa AgendaDay
            var adsList = await _context.AgendaDayStudent
                .Where(ads => ads.AgendaDayId == agendaDayId)
                .ToListAsync(ct);

            var alreadyLinkedIds = adsList
                .Select(ads => ads.StudentId)
                .ToList();

            // 4️⃣ Crear los que faltan
            var missingIds = currentStudentIds
                .Except(alreadyLinkedIds)
                .ToList();

            foreach (var studentId in missingIds)
            {
                var newAds = new AgendaDayStudent
                {
                    AgendaDayId = agendaDayId,
                    StudentId = studentId,
                    AgendaDayStudentStatus = 1,
                    Status = 1,
                    CreatedAt = now,
                    CompletedAt = now
                };

                _context.AgendaDayStudent.Add(newAds);
            }

            // 5️⃣ Eliminar los estudiantes que ya NO pertenecen al grupo
            var toDelete = adsList
                .Where(ads => !currentStudentIds.Contains(ads.StudentId))
                .ToList();

            foreach (var ads in toDelete)
            {
                _context.AgendaDayStudent.Remove(ads);
            }

            await _context.SaveChangesAsync(ct);

            _logger.LogInformation(
                "AgendaDay {AgendaDayId} sincronizada. Creados {Created}, eliminados {Deleted}.",
                agendaDayId,
                missingIds.Count,
                toDelete.Count);
        }




    }
    
}
