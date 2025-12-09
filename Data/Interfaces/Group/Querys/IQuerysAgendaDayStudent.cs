using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{
    public interface IQuerysAgendaDayStudent : IQuerys<AgendaDayStudent>
    {

        Task<List<AgendaDayStudentListItem>> StudentsByAgendaDayAsync(int agendaDayId,
        CancellationToken ct = default);

        // metodo de busqueda de agenda del estudiante con agenda lista para confirmar (confirmacion agenda)
        Task<List<AgendaDayStudent>> GetPendingConfirmationsByStudentAsync(
        int studentId,
        DateOnly date,
        CancellationToken ct = default);
    }
}