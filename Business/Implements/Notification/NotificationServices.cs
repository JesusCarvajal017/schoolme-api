using Entity.Context.Main;
using Entity.Model.Notification;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using Utilities.SignalR.Implements;
using Utilities.SignalR.Interfaces;

namespace Business.Implements.Notification
{
    public class NotificationServices : INotificationsService
    {

        private readonly AplicationDbContext _db;
        private readonly IHubContext<NotificationHub> _hub;

        public NotificationServices(AplicationDbContext db, IHubContext<NotificationHub> hub)
        { _db = db; _hub = hub; }

        public async Task<Guid> SendAsync(string userId, string title, string body, string type = "info", object? data = null, CancellationToken ct = default)
        {
            var notif = new Notifications
            {
                Type = type,
                Title = title,
                Body = body,
                DataJson = data is null ? null : JsonSerializer.Serialize(data)
            };
            var userNotif = new UserNotification
            {
                Notification = notif,
                UserId = userId,
                SentAt = DateTime.UtcNow
            };

            _db.Add(userNotif);
            await _db.SaveChangesAsync(ct);

            // Empujar al cliente (canal individual por usuario)
            await _hub.Clients.User(userId).SendAsync("notification", new
            {
                userNotificationId = userNotif.Id,
                notif.Id,
                notif.Type,
                notif.Title,
                notif.Body,
                notif.DataJson,
                notif.CreatedAt
            }, ct);

            return userNotif.Id;
        }

        public async Task MarkAsReadAsync(Guid userNotificationId, string userId, CancellationToken ct = default)
        {
            var item = await _db.Set<UserNotification>().FindAsync(new object?[] { userNotificationId }, ct);
            if (item is null || item.UserId != userId) return;
            item.IsRead = true; item.ReadAt = DateTime.UtcNow;
            await _db.SaveChangesAsync(ct);
        }

        public IQueryable<UserNotification> Query(string userId) =>
            _db.Set<UserNotification>().Where(x => x.UserId == userId)
               .OrderByDescending(x => x.Notification.CreatedAt)
               .AsNoTracking();



    }
}
