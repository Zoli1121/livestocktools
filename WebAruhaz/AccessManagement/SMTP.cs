//-----------------------------------------------------------------------
// <copyright file="SMTP.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    /// <summary>
    /// Defines the <see cref="SMTP" />
    /// </summary>
    public class SMTP
    {
        /// <summary>
        /// Gets or sets the smtpUserName
        /// </summary>
        public string SmtpUserName { get; set; }

        /// <summary>
        /// Gets or sets the smtpPassword
        /// </summary>
        public string SmtpPassword { get; set; }

        /// <summary>
        /// Gets or sets the smtpHost
        /// </summary>
        public string SmtpHost { get; set; }

        /// <summary>
        /// Gets or sets the smtpPort
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether smtpSSL
        /// </summary>
        public bool SmtpSSL { get; set; }

        /// <summary>
        /// Gets or sets the fromEmail
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// Gets or sets the fromFullName
        /// </summary>
        public string FromFullName { get; set; }
    }
}
