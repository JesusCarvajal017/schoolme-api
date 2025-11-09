using Microsoft.AspNetCore.SignalR;

namespace Utilities.SignalR.Implements
{
    public class NotificationHub : Hub
    {
        // Si usas autenticación, mapea el UserId del ClaimsPrincipal
        public override Task OnConnectedAsync() => base.OnConnectedAsync();
    }
}
