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


        [HttpGet("ObservationStudent/{agendaDayStudentId}/{academicLoadId}")]
        public async Task<IActionResult> GetObservation(
            int agendaDayStudentId,
            int academicLoadId)
                {
                    var result = await _query.GetObservationStudent(
                        agendaDayStudentId,
                        academicLoadId);


                    return Ok(result);
        }

        [HttpGet("ByAgendaDayStudent/{agendaDayStudentId:int}")]
        public async Task<IActionResult> GetByAgendaDayStudent(
        int agendaDayStudentId,
        CancellationToken ct)
        {
            var result = await _query.GetByAgendaDayStudentService(agendaDayStudentId, ct);
            return Ok(result);
        }
    }

}
