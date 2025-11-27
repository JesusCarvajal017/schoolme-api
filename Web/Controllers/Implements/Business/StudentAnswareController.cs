using Business.Interfaces.Querys;
using Entity.Dtos.Business.StudentAnsware;
using Entity.Dtos.Business.StudentAnswareOption;
using Entity.Model.Business;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class StudentAnswareController
       : GenericController<
       StudentAnswer,
       StudentAnswareDto,
       StudentAnswareDto>
    {
        private readonly ICommandStAswareServices _command;
        private readonly IQueryStudentAswareServices _querys;

        public StudentAnswareController(
           IQueryStudentAswareServices q,
            ICommandStAswareServices c)
          : base(q, c) 
        {
            _command = c;
            _querys = q; 
        }


        //[HttpPost("answers")]
        //public async Task<IActionResult> RegisterAnswers(
        //   [FromBody] RegisterStudentAnswersDto dto,
        //   CancellationToken ct)
        //{
        //    await _command.RegisterAnswersAsync(dto, ct);
        //    return NoContent();
        //}

        /// <summary>
        /// Registra o actualiza las respuestas de un estudiante en una agendaDayStudent dada.
        /// </summary>
        [HttpPost("answers")]
        public async Task<IActionResult> UpsertAnswers(
            [FromBody] RegisterStudentAnswersDto dto,
            CancellationToken ct)
        {
            // este método internamente crea o actualiza según existan respuestas previas
            await _command.UpdateAnswersAsync(dto, ct);

            return NoContent();
        }


        // GET api/AgendaDayStudent/{id}/answers
        [HttpGet("{agendaDayStudentId:int}/answers")]
        public async Task<IActionResult> GetAnswers(
            int agendaDayStudentId,
            CancellationToken ct)
        {
            var dto = await _querys.GetAnswersAsync(agendaDayStudentId, ct);
            return Ok(dto);
        }



    }

}
