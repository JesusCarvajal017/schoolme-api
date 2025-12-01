using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.Tution;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class TutionController
       : GenericController<
       Tutition,
       TutionReadDto,
       TutionDto>
    {

        private readonly IQueryTutitionServices _querys;
        public TutionController(
            IQueryTutitionServices q,
            ICommandService<Tutition, TutionDto> c)
          : base(q, c) 
        {
            _querys = q;
        }

        [HttpGet("TutitionGrade/{gradeId}")]
        public async Task<IActionResult> GetTutuionGradeController(int gradeId)
        {
            var result = await _querys.GetTutitionGrade(gradeId);
            return Ok(result);
        }


    }

}
