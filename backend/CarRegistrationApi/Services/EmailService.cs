using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CarRegistrationApi.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string to, string subject, string body)
        {
            if (string.IsNullOrEmpty(to)) throw new ArgumentNullException(nameof(to));

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Car Notifier", _configuration["EmailSettings:FromEmail"]));
            email.To.Add(new MailboxAddress("", to));
            email.Subject = subject;
            email.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration["EmailSettings:SmtpServer"], int.Parse(_configuration["EmailSettings:Port"] ?? "587"), SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        public void SendConfirmationEmail(string to, string fullName, string licensePlate, string service, DateTime expiryDate)
        {
            var subject = "Confirmare Înregistrare";
            var body = $"Stimat(ă) {fullName},\n\n" +
                       $"Detaliile mașinii dumneavoastră au fost înregistrate.\n\n" +
                       $"Detalii:\n" +
                       $"Mașina: {licensePlate}\n" +
                       $"Serviciul: {service}\n" +
                       $"Data Expirării: {expiryDate:dd/MM/yyyy}\n\n" +
                       "Vă mulțumim că ați folosit serviciul nostru.";

            SendEmail(to, subject, body);
        }

        public void SendReminderEmail(string to, string fullName, string service, DateTime expiryDate)
        {
            var subject = "Atenționare Expirare Serviciu";
            var body = $"Stimat(ă) {fullName},\n\n" +
                       $"Serviciul {service} pe care l-ați selectat este pe cale să expire pe data de {expiryDate:dd/MM/yyyy}.\n\n" +
                       "Vă mulțumim că ați folosit serviciul nostru.";

            SendEmail(to, subject, body);
        }

        public async Task SendContactMessageAsync(string fromEmail, string subject, string message)
        {
            var adminEmail = _configuration["EmailSettings:FromEmail"];
            var body = $"Mesaj de la: {fromEmail}\n\n{message}";
            await Task.Run(() => SendEmail(adminEmail, subject, body));
        }
    }
}
