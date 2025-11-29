
using Business.Interfaces.Querys;
using Entity.Dtos.Business.AgendaDay;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class AgendaDayController
       : GenericController<
       AgendaDay,
       AgendaDayDto,
       AgendaDayDto>
    {

        private readonly ICommandAgedaDayServices _command;
        public AgendaDayController(
            IQueryServices<AgendaDay, AgendaDayDto> q,
            ICommandAgedaDayServices c)
          : base(q, c) 
        {
            _command = c;
        }

        // POST api/AgendaDay/{agendaDayId}/close
        [HttpPost("{agendaDayId:int}/close")]
        public async Task<IActionResult> CloseAgendaDay(
            int agendaDayId,
            CancellationToken ct)
        {
            await _command.CloseAsync(agendaDayId, ct);
            return NoContent();
        }


    }

}
