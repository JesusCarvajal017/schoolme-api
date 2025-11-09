namespace Entity.Model.Notification
{
    public class UserNotification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid NotificationId { get; set; }
        public string UserId { get; set; } = default!;
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public DateTime? SentAt { get; set; }
        public Notifications Notification { get; set; } = default!;
    }
}
