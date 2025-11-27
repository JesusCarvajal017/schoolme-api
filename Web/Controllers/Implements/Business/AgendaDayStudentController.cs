using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.AgendaDayStudent;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class AgendaDayStudentController
       : GenericController<
       AgendaDayStudent,
       AgendaDayStudentDto,
       AgendaDayStudentDto>
    {

        private readonly IQueryAgendaStudentDayServices _query;
        public AgendaDayStudentController(
            IQueryAgendaStudentDayServices q,
            ICommandService<AgendaDayStudent, AgendaDayStudentDto> c)
        : base(q, c) 
        {
            _query = q;
        }

        // GET api/AgendaDayStudent/by-agenda-day/123
        [HttpGet("by-agenda-day/{agendaDayId:int}")]
        public async Task<IActionResult> GetByAgendaDay(
        int agendaDayId,
        CancellationToken ct)
        {
            var result = await _query.GetStudentsByAgendaDayAsync(agendaDayId, ct);
            return Ok(result);
        }
    }

}
