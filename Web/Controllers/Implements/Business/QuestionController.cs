using Business.Interfaces.Querys;
using Entity.Dtos.Business.Question;
using Entity.Model.Business;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class QuestionController
       : GenericController<
       Question,
       QuestionQueryDto,
       QuestionDto>
    {

        private readonly ICommandQuestionServices _command;
        public QuestionController(
            IQueryServices<Question, QuestionQueryDto> q,
            ICommandQuestionServices c)
          : base(q, c) 
        {
            _command = c;
        }

        [HttpPost]
        //[Authorize]
        public override async Task<IActionResult> Create(
        [FromBody][CustomizeValidator(RuleSet = "Full")] QuestionDto dto)
        {
            try
            {
                var created = await _command.CreateServices(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = created.Id },
                    created
                );
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    error = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message
                });
            }
        }


    }

}
