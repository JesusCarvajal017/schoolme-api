using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.CompositionAgenda;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class CompsitionAgendaController
       : GenericController<
       CompositionAgendaQuestion,
       CompositionDto,
       CompositionDto>
    {
        public CompsitionAgendaController(
            IQueryServices<CompositionAgendaQuestion, CompositionDto> q,
            ICommandService<CompositionAgendaQuestion, CompositionDto> c)
          : base(q, c) { }
    }

}
