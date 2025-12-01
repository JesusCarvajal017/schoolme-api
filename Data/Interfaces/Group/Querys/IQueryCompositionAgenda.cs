using Entity.Model.Business;

namespace Data.Interfaces.Group.Querys
{
    public interface IQueryCompositionAgenda : IQuerys<CompositionAgendaQuestion>
    {
        Task<IEnumerable<CompositionAgendaQuestion>> QuerAgendaComposite(int agendaId);

        Task<List<Question>> GetQuestionsByAgendaAsync(int agendaId, CancellationToken ct = default);
    }
}
