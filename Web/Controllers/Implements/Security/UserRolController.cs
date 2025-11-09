using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Security.UserRol;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Security 
{
    public class UserRolController
       : GenericController<
       UserRol,
       UserRolDto,
       UserRolCreateDtos>
    {

        protected readonly IQueryUserRolServices _services;

        public UserRolController(IQueryUserRolServices q, ICommandService<UserRol, UserRolCreateDtos> c) : base(q, c) 
        {
            _services = q;
        }

        [HttpGet("RolesUsuario/{IdUser}")]
        public async Task<IActionResult> GetUserRolsById(int IdUser)
        {
            var result = await _services.GetRolsUserServices(IdUser);
            return Ok(result);
        }

    }

}
