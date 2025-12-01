using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{
    public interface IQuerysAgendaDayStudent : IQuerys<AgendaDayStudent>
    {

        Task<List<AgendaDayStudentListItem>> StudentsByAgendaDayAsync(int agendaDayId,
        CancellationToken ct = default);
    }
}