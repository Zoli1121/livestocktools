//-----------------------------------------------------------------------
// <copyright file="EmailService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    using System.Threading.Tasks;

    using Microsoft.Extensions.Options;
    
    /// <summary>
    /// Defines the <see cref="EmailService" />
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="service">The service<see cref="IAuthenticationService"/></param>
        /// <param name="smtpOptions">The smtpOptions<see cref="IOptions{SMTP}"/></param>
        public EmailService(IAuthenticationService service, IOptions<SMTP> smtpOptions)
        {
            this.Service = service;
            this.Smtp = smtpOptions.Value;
        }

        /// <summary>
        /// Gets the Smtp
        /// </summary>
        private SMTP Smtp { get; }

        /// <summary>
        /// Gets the Service
        /// </summary>
        private IAuthenticationService Service { get; }

        /// <summary>
        /// The SendEmailAsync
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="subject">The subject<see cref="string"/></param>
        /// <param name="message">The message<see cref="string"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            Service.SendEmailByGmailAsync(Smtp.FromEmail, Smtp.FromFullName, subject, message, email, email, Smtp.SmtpUserName, Smtp.SmtpPassword, Smtp.SmtpHost, Smtp.SmtpPort, Smtp.SmtpSSL).Wait();
            return Task.CompletedTask;
        }
    }
}
