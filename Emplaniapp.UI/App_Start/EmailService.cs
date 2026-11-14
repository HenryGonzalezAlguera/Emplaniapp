using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

public class EmailService : IIdentityMessageService
{
    // Las credenciales SMTP son variables de entorno, nunca valores versionados.
    public async Task SendAsync(IdentityMessage message)
    {
        var smtpUser = Environment.GetEnvironmentVariable("EMPLANIAPP_SMTP_USERNAME");
        var smtpPassword = Environment.GetEnvironmentVariable("EMPLANIAPP_SMTP_PASSWORD");
        var fromEmail = Environment.GetEnvironmentVariable("EMPLANIAPP_MAIL_FROM");
        var fromName = ConfigurationManager.AppSettings["MailFromName"] ?? "Emplaniapp";

        if (string.IsNullOrWhiteSpace(smtpUser) || string.IsNullOrWhiteSpace(smtpPassword))
            throw new InvalidOperationException("SMTP no configurado. Defina las variables de entorno de correo.");

        if (string.IsNullOrWhiteSpace(fromEmail))
            fromEmail = smtpUser;

        using (var mail = new MailMessage())
        {
            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.IsBodyHtml = true;

            // SmtpClient usa host, puerto y TLS de system.net/mailSettings.
            using (var smtp = new SmtpClient())
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
