namespace Utilities.Helpers.interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(string fromName, string fromEmail, string toEmail,
                   string subject, string htmlBody, string? attachmentPath = null);

        Task SendTemplateAsync<TModel>(string toEmail,
                string subject,
                string templateKey,
                TModel model,
                string? fromName = null,
                string? fromEmail = null);
    }
}
