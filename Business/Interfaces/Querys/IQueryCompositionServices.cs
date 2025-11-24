using Entity.Dtos.Business.CompositionAgenda;
using Entity.Dtos.Business.Question;
using Entity.Model.Business;

namespace Business.Interfaces.Querys
{
    public interface IQueryCompositionServices : IQueryServices<CompositionAgendaQuestion, CompositionDto>
    {
        Task<IEnumerable<QuestionQueryDto>> AgendaCompsition(int id);
    }
}
