using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class GroupsController
       : GenericController<
       Groups,
       GroupsQueryDto,
       GroupsDto>
    {

        private readonly IQueryGrupsServices _queryGrupsServices;
        private readonly ICommandGroupsServices _commandGrupsServices;
        public GroupsController(
            IQueryGrupsServices q,
            ICommandGroupsServices c)
          : base(q, c) 
        {
            _queryGrupsServices = q;
            _commandGrupsServices = c;
        }


        [HttpGet("GroupsGrade/{gradeId}")]
        public async Task<IActionResult> GetGroupsGrade(int gradeId)
        {
            var result = await _queryGrupsServices.GetGrupsGrade(gradeId);
            return Ok(result);
        }


        [HttpPost("ChangeAgenda/{id:int}")]
        public async Task<IActionResult> ChangeAgenda(int id, [FromQuery] int? agendaId)
        {
            var result = await _commandGrupsServices.ChangeAgendaServies(id, agendaId);
            return Ok(result);
        }


        [HttpGet("GroupsAgendas/{agendaId}/{gradeId}")]
        public async Task<ActionResult<IEnumerable<GroupsAgendaDto>>> GetGroups(
            int agendaId, int gradeId)
        {
            var result = await _queryGrupsServices.GetGroupsAgendas(gradeId, agendaId);
            return Ok(result);
        }


    }

}
