//-----------------------------------------------------------------------
// <copyright file="EmailSenderExtensions.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="EmailSenderExtensions" />
    /// </summary>
    public static class EmailSenderExtensions
    {
        /// <summary>
        /// The SendEmailConfirmationAsync
        /// </summary>
        /// <param name="sender">The sender<see cref="IEmailService"/></param>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="link">The link<see cref="string"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public static Task SendEmailConfirmationAsync(this IEmailService sender, string email, string link)
        {
            return sender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
