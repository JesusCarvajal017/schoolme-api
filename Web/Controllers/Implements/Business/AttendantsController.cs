using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.Attendants;
using Entity.Model.Business;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class AttendantsController
       : GenericController<
       Attendants,
       AttQueryDto,
       AttendantsDto>
    {

        protected readonly IQueryAttendansServices _queryServices;
        public AttendantsController(
            IQueryAttendansServices q,
            ICommandService<Attendants, AttendantsDto> c)
          : base(q, c) 
        {
            _queryServices = q;
        }


        [HttpGet("Relation")]
        public virtual async Task<IActionResult> GetRelation([CustomizeValidator(RuleSet = "Full")] int? status, int personId) 
        {
            var resultQuery = await _queryServices.GetRelationServices(status, personId);

            return Ok(resultQuery);
        }


        [HttpGet("Relation/Students")]
        public virtual async Task<IActionResult> GetRelationStudent([CustomizeValidator(RuleSet = "Full")] int? status, int studentId)
        {
            var resultQuery = await _queryServices.GetRelationStudentsServices(status, studentId);

            return Ok(resultQuery);
        }
    }

}
