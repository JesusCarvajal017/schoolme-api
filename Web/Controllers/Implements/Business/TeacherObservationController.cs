using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.TeacherObservation;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class TeacherObservationController
       : GenericController<
       TeacherObservation,
       TeacherObservationDto,
       TeacherObservationDto>
    {

        private readonly IQueryTeacherObservationServices _query;
        public TeacherObservationController(
            IQueryTeacherObservationServices q,
            ICommandService<TeacherObservation, TeacherObservationDto> c)
          : base(q, c) {
            _query = q;
        }


        // Consulta de información completa de la persona
        [HttpGet("ObservationStudent/{agendaDayStudentId}")]
        public async Task<IActionResult> GetPersonBasic(int agendaDayStudentId)
        {
            var result = await _query.GetObservationStudent(agendaDayStudentId);
            return Ok(result);
        }
    }

}
