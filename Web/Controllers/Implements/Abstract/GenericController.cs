using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Global;
using Entity.Model.Global;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Web.Controllers.Implements.Abstract
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public abstract class GenericController<
            TEntity,
            TReadDto,
            TWriteDto> 
            : ControllerBase
          where TEntity : ABaseEntity   
          where TReadDto : ABaseDto
          where TWriteDto : ABaseDto
    {
        protected readonly IQueryServices<TEntity, TReadDto> _querySvc;
        protected readonly ICommandService<TEntity, TWriteDto> _cmdSvc;

        protected GenericController(
            IQueryServices<TEntity, TReadDto> querySvc,
            ICommandService<TEntity, TWriteDto> cmdSvc)
        {
            _querySvc = querySvc;
            _cmdSvc = cmdSvc;
        }

        [HttpGet]
        [OutputCache]
        //[Authorize]
        public virtual async Task<IActionResult> GetAll([CustomizeValidator(RuleSet = "Full")]  int? status) => Ok(await _querySvc.GetAllServices(status));

        [HttpGet("{id}")]
        //[Authorize]
        public virtual async Task<IActionResult> GetById([CustomizeValidator(RuleSet = "Full")]  int id) => Ok(await _querySvc.GetByIdServices(id));

        [HttpPost]
        //[Authorize]
        public virtual async Task<IActionResult> Create([FromBody][CustomizeValidator(RuleSet = "Full")] TWriteDto dto)
        {
            var created = await _cmdSvc.CreateServices(dto);

            var id = created.Id;

            return CreatedAtAction(
                nameof(GetById),
                new { id = id },
              created
            );
        }

        [HttpPut]
        //[Authorize]
        public virtual async Task<IActionResult> Update([FromBody] [CustomizeValidator(RuleSet = "Full")] TWriteDto dto) => Ok(await _cmdSvc.UpdateServices(dto));

        [HttpDelete("{id}")]
        //[Authorize]
        public virtual async Task<IActionResult> Delete([CustomizeValidator(RuleSet = "Full")] int id) => Ok(await _cmdSvc.DeleteServices(id));

        [HttpDelete("{id:int}/{status:int}")]
        //[Authorize]
        public virtual async Task<IActionResult> DeleteLogica([CustomizeValidator(RuleSet = "Full")] int id, int status) => Ok(await _cmdSvc.DeleteLogicalServices(id, status));

        [HttpPatch]
        public virtual async Task<IActionResult> PartialUpdate([FromBody] [CustomizeValidator(RuleSet = "Patch")] TWriteDto dto) => Ok(await _cmdSvc.PathServices(dto));
    }
}