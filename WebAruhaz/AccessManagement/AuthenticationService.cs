//-----------------------------------------------------------------------
// <copyright file="AuthenticationService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using WebAruhaz.Models.UserModels;

    /// <summary>
    /// Defines the <see cref="AuthenticationService" />
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Defines the signInManager
        /// </summary>
        private readonly SignInManager<ApplicationUser> signInManager;

        /// <summary>
        /// Defines the roles
        /// </summary>
        private readonly IRoleService roles;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="signInManager">The signInManager<see cref="SignInManager{ApplicationUser}"/></param>
        /// <param name="roles">The roles<see cref="IRoleService"/></param>
        public AuthenticationService(SignInManager<ApplicationUser> signInManager, IRoleService roles)
        {
            this.signInManager = signInManager;
            this.roles = roles;
        }

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
        public async Task SendEmailByGmailAsync(string fromEmail, string fromFullName, string subject, string messageBody, string toEmail, string toFullName, string smtpUser, string smtpPassword, string smtpHost, int smtpPort, bool smtpSSL)
        {
            var body = messageBody;
            var message = new MailMessage();
            message.To.Add(new MailAddress(toEmail, toFullName));
            message.From = new MailAddress(fromEmail, fromFullName);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword
                };
                smtp.Credentials = credential;
                smtp.Host = smtpHost;
                smtp.Port = smtpPort;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }
        }

        /// <summary>
        /// The IsAccountActivatedAsync
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <param name="userManager">The userManager<see cref="UserManager{ApplicationUser}"/></param>
        /// <returns>The <see cref="Task{bool}"/></returns>
        public async Task<bool> IsAccountActivatedAsync(string email, UserManager<ApplicationUser> userManager)
        {
            bool result = false;
            try
            {
                var user = await userManager.FindByNameAsync(email);
                if (user != null)
                {
                    ////Add this to check if the email was confirmed.
                    if (await userManager.IsEmailConfirmedAsync(user))
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// The UpdateRoles
        /// </summary>
        /// <param name="appUser">The appUser<see cref="ApplicationUser"/></param>
        /// <param name="currentLoginUser">The currentLoginUser<see cref="ApplicationUser"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task UpdateRoles(ApplicationUser appUser, ApplicationUser currentLoginUser)
        {
            try
            {
                await this.roles.UpdateRoles(appUser, currentLoginUser);
                if (currentLoginUser.Id == appUser.Id)
                {
                    await this.signInManager.SignInAsync(appUser, false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
