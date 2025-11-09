using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.AcademicLoad;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class AcademicLoadController
       : GenericController<
       AcademicLoad,
       AcademicLoadReadDto,
       AcademicLoadDto>
    {

        private readonly IQueryAcLoadServices _queryAcLoadServices;
        public AcademicLoadController(
            IQueryAcLoadServices q,
            ICommandService<AcademicLoad, AcademicLoadDto> c)
          : base(q, c) {
            _queryAcLoadServices = q;
        
        }


        [HttpGet("teacherLoad/{techerId}")]
        public async Task<IActionResult> GetUserRolsById(int techerId, int? status)
        {
            var result = await _queryAcLoadServices.GetTeacherLoad(techerId, status);
            return Ok(result);
        }
    }

}
