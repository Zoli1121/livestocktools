//-----------------------------------------------------------------------
// <copyright file="IRoleService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    using System.Threading.Tasks;
    using WebAruhaz.Models.UserModels;

    /// <summary>
    /// Defines the <see cref="IRoleService" />
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// The UpdateRoles
        /// </summary>
        /// <param name="appUser">The appUser<see cref="ApplicationUser"/></param>
        /// <param name="currentUserLogin">The currentUserLogin<see cref="ApplicationUser"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task UpdateRoles(ApplicationUser appUser, ApplicationUser currentUserLogin);
    }
}
