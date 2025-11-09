using Business.Implements.Auth;
using Entity.Dtos.Especific.System;
using Entity.Dtos.Security.Auth;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers.Implements.Auth
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly AuthBusiness  _authBusiness;
        private readonly ILogger<AuthController> _logger;

        public AuthController
            (
                AuthBusiness authBussines,
                ILogger<AuthController> logger
             
            )
        {
            _authBusiness = authBussines;

            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Object), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ValidationUser([FromBody] CredencialesDto login)
        {
            try
            {
                var update = await _authBusiness.AuthApp(login);
                return Ok(update);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida el User con Name: {UserId} no tien acceso", login.Email);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "User no encontrado con ID: {UserId}", login.Email);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el User con ID: {UserId}", login.Email);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("ResetPassword/{email}")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            StatusDto result = await _authBusiness.ResetPasswordServices(email);
            return Ok(result);
        }

        [HttpPost("ValidationCode/{email}/{codigo}")]
        public async Task<IActionResult> CodeValidation(string email, string codigo)
        {
            StatusDto result = await _authBusiness.ValidateCodigo(email, codigo);
            return Ok(result);
        }


    }
}
