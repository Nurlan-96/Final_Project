using Microsoft.Extensions.Options;
using SharedKernel.Domain;
using System.Net.Mail;
using System.Net;
using SharedKernel.Domain.Settings;
using System.Text;

namespace EmailModule.Manager
{
    public class EmailManager(IOptions<EmailSettings> settings) : IEmailManager
	{
		private readonly EmailSettings _settings = settings.Value;

        public string LoadHTML(string path)
        {
            using StreamReader reader = File.OpenText(path);
            return reader.ReadToEnd();
        }

		/// <summary>
		/// Replacements are dictionaries that can replace custom tags we add into HTML Templates.
		/// Custom Tags are always inside {} Example: {OTP}
		/// </summary>
		/// <param name="path"></param>
		/// <param name="replacements"></param>
		/// <returns></returns>
        public string LoadHTML(string path, Dictionary<string, string> replacements)
        {
            string htmlContent = LoadHTML(path);

            foreach (KeyValuePair<string, string> replacement in replacements)
            {
                htmlContent = htmlContent.Replace($"{{{replacement.Key}}}", replacement.Value);
            }

            return htmlContent;
        }

        public async Task SendEmail(Email email, CancellationToken cancellationToken)
		{
			using MailMessage message = new();
			message.IsBodyHtml = email.IsHtml;
			message.From = new MailAddress(_settings.From);
            message.BodyEncoding = Encoding.UTF8;
            #region Custom
            message.To.Add(new MailAddress(email.To));
			message.Subject = email.Subject;
			message.Body = email.Body;
            #endregion

            using SmtpClient smtpClient = new(_settings.SmtpServer);
			smtpClient.Port = _settings.Port;
			smtpClient.Credentials = new NetworkCredential(_settings.From, _settings.Password);
            smtpClient.EnableSsl = true; //false;
			await smtpClient.SendMailAsync(message, cancellationToken);
		}

        public string GetTemplatePath()
        {
            return _settings.TemplateDirectory;
        }
    }
}