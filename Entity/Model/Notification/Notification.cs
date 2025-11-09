namespace Entity.Model.Notification
{
    public class Notifications
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Type { get; set; } = "info";
        public string Title { get; set; } = default!; 
        public string Body { get; set; } = default!; 
        public string? DataJson { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
