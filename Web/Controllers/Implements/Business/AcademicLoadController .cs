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

        [HttpGet("teacher/{idTeacher}")]
        public async Task<ActionResult<IEnumerable<LoadByDayReadDto>>> GetTeacherLoad(
            int idTeacher,
            [FromQuery] int? status,
            int? day  // aquí recibes el flag del día
        )
        {
            var result = await _queryAcLoadServices.GetTeacherLoadDay(idTeacher, status, day);
            return Ok(result);
        }

        /// <summary>
        /// Devuelve las clases que dicta hoy un docente (según su carga académica),
        /// incluyendo el estado de la AgendaDay del día de hoy para cada grupo.
        /// </summary>
        /// GET: api/AcademicLoad/Teacher/5/Today
        [HttpGet("teacher/{teacherId:int}/today")]
        public async Task<IActionResult> GetTodayLoadsByTeacher(
            int teacherId,
            CancellationToken ct)
        {
            var result = await _queryAcLoadServices.GetTodayLoadsByTeacherAsync(teacherId, ct);
            return Ok(result);
        }
    }

}
