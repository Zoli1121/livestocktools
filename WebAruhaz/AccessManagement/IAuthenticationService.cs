//-----------------------------------------------------------------------
// <copyright file="IAuthenticationService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    
    using WebAruhaz.Models.UserModels;

    /// <summary>
    /// Defines the <see cref="IAuthenticationService" />
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// The SendEmailByGmailAsync
        /// </summary>
        /// <param name="fromEmail">The fromEmail<see cref="string"/></param>
        /// <param name="fromFullName">The fromFullName<see cref="string"/></param>
        /// <param name="subject">The subject<see cref="string"/></param>
        /// <param name="messageBody">The messageBody<see cref="string"/></param>
        /// <param name="toEmail">The toEmail<see cref="string"/></param>
        /// <param name="toFullName">The toFullName<see cref="string"/></param>
        /// <param name="smtpUser">The smtpUser<see cref="string"/></param>
        /// <param name="smtpPassword">The smtpPassword<see cref="string"/></param>
        /// <param name="smtpHost">The smtpHost<see cref="string"/></param>
        /// <param name="smtpPort">The smtpPort<see cref="int"/></param>
        /// <param name="smtpSSL">The smtpSSL<see cref="bool"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task SendEmailByGmailAsync(
            string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL);

        /// <summary>
        /// The IsAccountActivatedAsync
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="userManager">The userManager<see cref="UserManager{ApplicationUser}"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        Task<bool> IsAccountActivatedAsync(string email, UserManager<ApplicationUser> userManager);

        /// <summary>
        /// The UpdateRoles
        /// </summary>
        /// <param name="appUser">The appUser<see cref="ApplicationUser"/></param>
        /// <param name="currentUserLogin">The currentUserLogin<see cref="ApplicationUser"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task UpdateRoles(ApplicationUser appUser, ApplicationUser currentUserLogin);
    }
}
