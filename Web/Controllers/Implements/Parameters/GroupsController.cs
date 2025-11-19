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
        public GroupsController(
            IQueryGrupsServices q,
            ICommandService<Groups, GroupsDto> c)
          : base(q, c) 
        {
            _queryGrupsServices = q;
        }


        [HttpGet("GroupsGrade/{gradeId}")]
        public async Task<IActionResult> GetGroupsGrade(int gradeId)
        {
            var result = await _queryGrupsServices.GetGrupsGrade(gradeId);
            return Ok(result);
        }
    }

}
