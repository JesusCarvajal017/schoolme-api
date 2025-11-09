using Entity.Model.Notification;

namespace Utilities.SignalR.Interfaces
{
    public interface INotificationsService
    {
        Task<Guid> SendAsync(string userId, string title, string body, string type = "info", object? data = null, CancellationToken ct = default);
        Task MarkAsReadAsync(Guid userNotificationId, string userId, CancellationToken ct = default);
        IQueryable<UserNotification> Query(string userId); // para listar
    }
}
