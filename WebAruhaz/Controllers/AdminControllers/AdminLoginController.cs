//-----------------------------------------------------------------------
// <copyright file="AdminLoginController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.AdminControllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using WebAruhaz.Models.UserModels;
    using WebAruhaz.Models.ViewModels.AccountViewModels;

    /// <summary>
    /// Defines the <see cref="AdminLoginController" />
    /// </summary>
    public class AdminLoginController : Controller
    {
        /// <summary>
        /// Defines the _userManager
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// Defines the _signInManager
        /// </summary>
        private readonly SignInManager<ApplicationUser> signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminLoginController"/> class.
        /// </summary>
        /// <param name="userManager">The userManager<see cref="UserManager{ApplicationUser}"/></param>
        /// <param name="signInManager">The signInManager<see cref="SignInManager{ApplicationUser}"/></param>
        public AdminLoginController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="ViewResult"/></returns>
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="loginModel">The loginModel<see cref="LoginViewModel"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user =
                    await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        if (user.MainAdmin)
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/AdminHome/Index");
                        }
                    }

                    ModelState.AddModelError("", "Hozzáférés megtagadva");
                    return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                }
            }

            return View(loginModel);
        }

        /// <summary>
        /// The Logout
        /// </summary>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="Task{RedirectResult}"/></returns>
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ViewResult"/></returns>
        public ViewResult Index()
        {
            return View();
        }
    }
}
