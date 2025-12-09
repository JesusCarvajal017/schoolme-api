using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz de extension de user rol
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuerysAgendaDay : IQuerys<AgendaDay>
    {
        Task<List<AgendaDay>> GetByDateAsync(DateOnly date, CancellationToken ct = default);

    }
}