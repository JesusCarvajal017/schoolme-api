using Business.Implements.Auth;
using Data.Implements.View;
using Entity.Dtos.Security.Auth;
using Entity.Dtos.View;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers.Implements.View
{
    [Route("api/[controller]")]
    [ApiController]
    //[Route("api/Menu")]
    public class ViewController : ControllerBase
    {
        // no deberia conectarse directamente con la data
        private readonly ViewData  _data;
        private readonly ILogger<ViewController> _logger;

        public ViewController
            (
                ViewData service,
                ILogger<ViewController> logger
             
            )
        {
            _data = service;
            _logger = logger;
        }

        [HttpGet("Menu")]

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> MenuServices(int rolId)
        {
            if (rolId <= 0) 
            {
                return BadRequest("El Id del rol debe ser mayor que 0.");
            }

            try
            {
                var update = await _data.BuildMenuAsync(rolId);
                return Ok(update);
            }
            catch (Exception ex) {

                _logger.LogError("Error al consultar la informacion del menú");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno consultado el menu");
            }
        }


        [HttpGet("Registers")]
        public async Task<IActionResult> CountRegisters()
        {
         
            try
            {
                var query = await _data.QueryCountRegister();
                return Ok(query);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error al consultar la informacion del los registros");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno consultado los registros");
            }
        }


        /// <summary>
        /// Devuelve todo el dashboard (pie + barras + línea) en un solo objeto.
        /// </summary>
        [HttpGet("dasboard")]
        public async Task<ActionResult<DashboardDto>> GetDashboard()
        {
            var dto = await _data.GetDashboardAsync();
            return Ok(dto);
        }

    }
}
