using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.GroupDirector;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class GroupDirectorController
       : GenericController<
       GroupDirector,
       GroupDirectorQueryDto,
       GroupDirectorDto>
    {
         private readonly IQueryGroupDirectorServices _querys;

        public GroupDirectorController(
            IQueryGroupDirectorServices q,
            ICommandService<GroupDirector, GroupDirectorDto> c)
          : base(q, c) 
        {
            _querys = q;    
        
        }

        [HttpGet("Groups/{teacherId}")]
        public async Task<IActionResult> GetGroupLeader(int teacherId)
        {
            var result = await _querys.GetGroupsDirect(teacherId);
            return Ok(result);
        }


    }

}
