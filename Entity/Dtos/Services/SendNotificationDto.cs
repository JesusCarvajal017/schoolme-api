namespace Entity.Dtos.Services
{
    public class SendNotificationDto
    {
        public string UserId { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Body { get; set; } = default!;
        public string? Type { get; set; }
        public object? Data { get; set; }
    }
}
