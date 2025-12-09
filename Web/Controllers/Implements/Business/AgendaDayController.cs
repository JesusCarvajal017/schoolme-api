
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
        private readonly IQueryAgendaDayServices _query;
        public AgendaDayController(
            IQueryAgendaDayServices q,
            ICommandAgedaDayServices c)
          : base(q, c) 
        {
            _command = c;
            _query = q;
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


        // GET api/AgendaDay/Today
        [HttpGet("Today")]
        public async Task<IActionResult> GetTodayAgendaDays(CancellationToken ct)
        {
            var result = await _query.GetTodayAgendaDaysAsync(ct);
            return Ok(result);
        }

        /// <summary>
        /// Reabre una AgendaDay: pone ClosedAt en null
        /// y resetea AgendaDayStudentStatus = 1 para todos los estudiantes de esa agenda.
        /// </summary>
        [HttpPut("{agendaDayId:int}/Reopen")]
        public async Task<IActionResult> ReopenAgendaDay(
            int agendaDayId,
            CancellationToken ct)
        {
            await _command.ReopenAgendaDayAsync(agendaDayId, ct);
            return NoContent();
        }


    }

}
