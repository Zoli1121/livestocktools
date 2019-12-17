//-----------------------------------------------------------------------
// <copyright file="UrlHelperExtensions.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    using Microsoft.AspNetCore.Mvc;
    using WebAruhaz.Controllers;

    /// <summary>
    /// Defines the <see cref="UrlHelperExtensions" />
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// The EmailConfirmationLink
        /// </summary>
        /// <param name="urlHelper">The urlHelper<see cref="IUrlHelper"/></param>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="code">The code<see cref="string"/></param>
        /// <param name="scheme">The scheme<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        /// <summary>
        /// The ResetPasswordCallbackLink
        /// </summary>
        /// <param name="urlHelper">The urlHelper<see cref="IUrlHelper"/></param>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="code">The code<see cref="string"/></param>
        /// <param name="scheme">The scheme<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
