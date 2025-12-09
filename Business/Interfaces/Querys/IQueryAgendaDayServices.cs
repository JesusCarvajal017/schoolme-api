using Entity.Dtos.Business.AgendaDay;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryAgendaDayServices : IQueryServices<AgendaDay, AgendaDayDto>
    {
        Task<List<AgendaDayAdminListDto>> GetTodayAgendaDaysAsync(CancellationToken ct = default);
    }
}
