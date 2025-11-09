using Business.Interfaces.Querys;
using Entity.Dtos.Especific;
using Entity.Dtos.Especific.Security;
using Entity.Dtos.Security.User;
using Entity.Model.Security;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Security 
{
    public class UserController
       : GenericController<
       User,
       UserQueryDto,
       UserDto>
    {
        // en caso de extender el controlador en la parte de commandos

        protected readonly ICommandUserServices _services;

        public UserController(
            IQueryServices<User, UserQueryDto> q,
            ICommandUserServices c)
          : base(q, c) 
        {
            _services = c;
        }


        [NonAction] 
        [HttpPost]
        //[Authorize]
        public override async Task<IActionResult> Create([FromForm][CustomizeValidator(RuleSet = "Full")] UserDto dto)
        {
            var created = await _cmdSvc.CreateServices(dto);

            var id = created.Id;

            return CreatedAtAction(
                nameof(GetById),
                new { id = id },
              created
            );
        }

        [HttpPost]
        //[Authorize]
        public virtual async Task<IActionResult> CreateRemasted([FromForm][CustomizeValidator(RuleSet = "Full")] UserCreateDto dto)
        {
            var created = await _services.CreateRemastered(dto);

            var id = created.Id;

            return CreatedAtAction(
                nameof(GetById),
                new { id = id },
              created
            );
        }


        [HttpPut]
        //[Authorize]
        public override async Task<IActionResult> Update([FromForm][CustomizeValidator(RuleSet = "Full")] UserDto dto) 
        {

            return Ok(await _cmdSvc.UpdateServices(dto));
        }

        [HttpPost("passwordUpdate")]
        //[Authorize]
        public virtual async Task<IActionResult> UpdatePassword([FromBody][CustomizeValidator(RuleSet = "Full")] ChangePassword dto)
        {

            return Ok(await _services.ChangePasswordServices(dto));
        }


        [HttpPost("photoUpdate")]
        //[Authorize]
        public virtual async Task<IActionResult> UpdatePhoto([FromForm][CustomizeValidator(RuleSet = "Full")] ChangePhotoDto dto)
        {
            return Ok(await _services.ChangePhotoServices(dto));
        }


    }

}
