using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryAgendaStudentDayServices : IQueryServices<AgendaDayStudent, AgendaDayStudentDto>
    {
        Task<List<AgendaDayStudentListDto>> GetStudentsByAgendaDayAsync(
           int agendaDayId,
           CancellationToken ct = default);


        Task<List<AgendaConfirmationQueryDto>> GetPendingConfirmationsByStudentAsync(
        int studentId,
        CancellationToken ct = default);

        /// <summary>
        /// Revisa los estudiantes actuales del grupo de la AgendaDay
        /// y crea AgendaDayStudent para los que no tengan registro.
        /// NO borra nada, solo completa lo que falta.
        /// </summary>
        Task SyncAgendaDayStudentsAsync(int agendaDayId, CancellationToken ct = default);
    }
}
