using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryAgendaStudentDayServices : IQueryServices<AgendaDayStudent, AgendaDayStudentDto>
    {
        Task<List<AgendaDayStudentListDto>> GetStudentsByAgendaDayAsync(
           int agendaDayId,
           CancellationToken ct = default);
    }
}
