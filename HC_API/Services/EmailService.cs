using HC_API.Data;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace HC_API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public void EnviarEmail(EmailDTO peticion)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(peticion.De));
            email.To.Add(MailboxAddress.Parse(peticion.Para));
            email.Subject = peticion.Asunto;
            email.Body = new TextPart(TextFormat.Html) { Text = peticion.Contenido };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("AppSettings:EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("AppSettings:EmailUserName").Value, _configuration.GetSection("AppSettings:EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}