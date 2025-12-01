using Entity.Dtos.Business.CompositionAgenda;
using Entity.Dtos.Business.Question;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryCompositionServices : IQueryServices<CompositionAgendaQuestion, CompositionDto>
    {
        Task<IEnumerable<QuestionCompositionQueryDto>> AgendaCompsition(int id);

        Task<List<QuestionCompositionQueryDto>> GetQuestionsByAgendaAsync(int agendaId, CancellationToken ct = default);
    }
}
