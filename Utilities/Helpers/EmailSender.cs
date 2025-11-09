using Entity.Dtos.Services;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Utilities.Helpers.interfaces;

namespace Utilities.Helpers
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpOptions _opt;
        private readonly IEmailTemplateRenderer _renderer;

        public EmailSender(IOptions<SmtpOptions> options, IEmailTemplateRenderer render)
        {
            _opt = options.Value;
            _renderer = render;
        }

        /// <summary>
        /// Metodo de enviar correos electronicos
        /// </summary>
        /// <param name="fromName">Nombre de quien envia el correo electronico</param>
        /// <param name="fromEmail">email de quien envia el correo electronico</param>
        /// <param name="toEmail">email de destino</param>
        /// <param name="subject">asunto del email </param>
        /// <param name="htmlBody">cuerpo del email  </param>
        /// <param name="attachmentPath">adjunto (opcional)  </param>
        public async Task SendAsync(string fromName, string fromEmail, string toEmail,
                               string subject, string htmlBody,
                               string? attachmentPath = null)
        {

            /// construccion del mesaje
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(fromName ?? _opt.FromName, fromEmail ?? _opt.FromEmail));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = subject;


            var builder = new BodyBuilder { HtmlBody = htmlBody };

            if (!string.IsNullOrWhiteSpace(attachmentPath))
                builder.Attachments.Add(attachmentPath);

            message.Body = builder.ToMessageBody();

            using var client = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                var socketOption = _opt.UseSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;
                await client.ConnectAsync(_opt.Host, _opt.Port, socketOption);

                if (!string.IsNullOrWhiteSpace(_opt.User))
                    await client.AuthenticateAsync(_opt.User, _opt.Password);

                await client.SendAsync(message);
            }
            finally
            {
                if (client.IsConnected)
                    await client.DisconnectAsync(true);
            }
        }

        // Genra el correo electronico con el template qeu se le asigne
        public async Task SendTemplateAsync<TModel>(
                string toEmail,
                string subject,
                string templateKey,
                TModel model,
                string? fromName = null,
                string? fromEmail = null)
        {
            var htmlBody = await _renderer.RenderAsync(templateKey, model);
            await SendAsync(fromName ?? _opt.FromName, fromEmail ?? _opt.FromEmail, toEmail, subject, htmlBody);
        }

    }
}
