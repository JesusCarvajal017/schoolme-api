using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.CompositionAgenda;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class CompsitionAgendaController
       : GenericController<
       CompositionAgendaQuestion,
       CompositionDto,
       CompositionDto>
    {

        private readonly IQueryCompositionServices _queryCompositionServices;

        public CompsitionAgendaController(
            IQueryCompositionServices q,
            ICommandService<CompositionAgendaQuestion, CompositionDto> c)
          : base(q, c) {
            _queryCompositionServices = q;
        }

        // Consulta de información completa de la persona
        [HttpGet("AgendaComposition/{agendaId}")]
        public async Task<IActionResult> GetPersonBasic(int agendaId)
        {
            var result = await _queryCompositionServices.AgendaCompsition(agendaId);
            return Ok(result);
        }

    }




}
