//-----------------------------------------------------------------------
// <copyright file="RoleService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using WebAruhaz.Models.UserModels;

    /// <summary>
    /// Defines the <see cref="RoleService" />
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// Defines the _userManager
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// Defines the _roleManager
        /// </summary>
        private readonly RoleManager<IdentityRole> roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="userManager">The userManager<see cref="UserManager{ApplicationUser}"/></param>
        /// <param name="roleManager">The roleManager<see cref="RoleManager{IdentityRole}"/></param>
        public RoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
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
                IList<string> roles = await userManager.GetRolesAsync(appUser);
                foreach (var item in roles)
                {
                    if (!item.Contains("Line"))
                    {
                        await userManager.RemoveFromRoleAsync(appUser, item);
                    }
                }

                Type type = appUser.GetType();
                foreach (System.Reflection.PropertyInfo item in type.GetProperties())
                {
                    if (item.Name.Contains("Role"))
                    {
                        bool isRole = (bool)item.GetValue(appUser, null);
                        if (isRole)
                        {
                            string roleName = item.Name.Replace("Role", string.Empty);
                            if (!await roleManager.RoleExistsAsync(roleName))
                            {
                                await roleManager.CreateAsync(new IdentityRole(roleName));
                            }

                            await userManager.AddToRoleAsync(appUser, roleName);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
