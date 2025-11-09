using Entity.Dtos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.SignalR.Interfaces;   // tu interfaz del servicio de notificaciones

namespace Web.Controllers.Implements.Notification
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // obliga a que el usuario esté autenticado
    public class NotificationController : ControllerBase
    {
        private readonly INotificationsService _notificationsService;

        public NotificationController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        /// <summary>
        /// Lista las notificaciones del usuario actual
        /// </summary>
        [HttpGet]
        public IActionResult Get([FromQuery] int? take = 50, [FromQuery] bool? unread = false)
        {
            var userId = User.Identity?.Name ?? ""; // o extraer del claim
            var query = _notificationsService.Query(userId);

            if (unread == true)
                query = query.Where(x => !x.IsRead);

            var list = query
                .Take(take ?? 50)
                .Select(x => new
                {
                    x.Id,
                    x.NotificationId,
                    x.IsRead,
                    x.ReadAt,
                    x.SentAt,
                    x.Notification.Type,
                    x.Notification.Title,
                    x.Notification.Body,
                    x.Notification.DataJson,
                    x.Notification.CreatedAt
                })
                .ToList();

            return Ok(list);
        }

        /// <summary>
        /// Marca una notificación como leída
        /// </summary>
        [HttpPost("read/{id:guid}")]
        public async Task<IActionResult> MarkAsRead(Guid id, CancellationToken ct)
        {
            var userId = User.Identity?.Name ?? "";
            await _notificationsService.MarkAsReadAsync(id, userId, ct);
            return NoContent();
        }

        /// <summary>
        /// Envía una notificación (por sistema o administrador)
        /// </summary>
        [HttpPost("send")]
        [Authorize(Roles = "Admin")] // o cámbialo según tu lógica
        public async Task<IActionResult> Send([FromBody] SendNotificationDto dto, CancellationToken ct)
        {
            var id = await _notificationsService.SendAsync(
                dto.UserId,
                dto.Title,
                dto.Body,
                dto.Type ?? "info",
                dto.Data,
                ct
            );

            return Ok(new { id });
        }
    }

    
}
