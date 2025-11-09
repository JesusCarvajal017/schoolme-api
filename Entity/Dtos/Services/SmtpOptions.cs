namespace Entity.Dtos.Services
{
    public class SmtpOptions
    {
        public string Host { get; set; } = "";
        public int Port { get; set; } = 587;
        public string User { get; set; } = "";
        public string Password { get; set; } = "";
        public bool UseSsl { get; set; } = true; 
        public string FromName { get; set; } = "";
        public string FromEmail { get; set; } = "";
    }
}
