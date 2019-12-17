//-----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
 
    using WebAruhaz.AccessManagement;
    using WebAruhaz.Controllers.WebShopControllers;
    using WebAruhaz.Models.UserModels;
    using WebAruhaz.Models.ViewModels.AccountViewModels;
    using WebAruhaz.Models.ViewModels.WebShopViewModels;

    /// <summary>
    /// Defines the <see cref="AccountController" />
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Defines the userManager
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// Defines the signInManager
        /// </summary>
        private readonly SignInManager<ApplicationUser> signInManager;

        /// <summary>
        /// Defines the emailService
        /// </summary>
        private readonly IEmailService emailService;

        /// <summary>
        /// Defines the logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The userManager<see cref="UserManager{ApplicationUser}"/></param>
        /// <param name="signInManager">The signInManager<see cref="SignInManager{ApplicationUser}"/></param>
        /// <param name="emailService">The emailService<see cref="IEmailService"/></param>
        /// <param name="logger">The logger<see cref="ILogger{AccountController}"/></param>
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailService emailService,
            ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailService = emailService;
            this.logger = logger;
        }

        /// <summary>
        /// Gets or sets the ErrorMessage
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="model">The model<see cref="RegisterViewModel"/></param>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    logger.LogInformation("User created a new account with password.");

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await emailService.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    ////diallowed signin for self registration, email should be confirmed first
                    ////await _signInManager.SignInAsync(user, isPersistent: false);
                    logger.LogInformation("User created a new account with password.");
                    return RedirectToConfirmEmailNotification();
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="model">The model<see cref="WebShopLoginViewModel"/></param>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(WebShopLoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in.");

                    return RedirectToLocal(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    logger.LogWarning("User account locked out.");
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        /// <summary>
        /// The LoginWithRecoveryCode
        /// </summary>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        /// <summary>
        /// The LoginWithRecoveryCode
        /// </summary>
        /// <param name="model">The model<see cref="LoginWithRecoveryCodeViewModel"/></param>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

            var result = await signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
            {
                logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
                return View();
            }
        }

        /// <summary>
        /// The Lockout
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        /// <summary>
        /// The Logout
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        /// <summary>
        /// The ConfirmEmail
        /// </summary>
        /// <param name="userId">The userId<see cref="string"/></param>
        /// <param name="code">The code<see cref="string"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }

            var result = await userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        /// <summary>
        /// The ForgotPassword
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// The ForgotPassword
        /// </summary>
        /// <param name="model">The model<see cref="ForgotPasswordViewModel"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                await emailService.SendEmailAsync(
                    model.Email, 
                    "Reset Password",
                   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");

                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// The ForgotPasswordConfirmation
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        /// <summary>
        /// The ResetPassword
        /// </summary>
        /// <param name="code">The code<see cref="string"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }

            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        /// <summary>
        /// The ResetPassword
        /// </summary>
        /// <param name="model">The model<see cref="ResetPasswordViewModel"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            var result = await userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            AddErrors(result);
            return View();
        }

        /// <summary>
        /// The ResetPasswordConfirmation
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        /// <summary>
        /// The AccessDenied
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        /// <summary>
        /// The ConfirmEmailNotification
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmEmailNotification()
        {
            return View();
        }

        /// <summary>
        /// The AddErrors
        /// </summary>
        /// <param name="result">The result<see cref="IdentityResult"/></param>
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        /// <summary>
        /// The RedirectToLocal
        /// </summary>
        /// <param name="returnUrl">The returnUrl<see cref="string"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        /// <summary>
        /// The RedirectToConfirmEmailNotification
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        private IActionResult RedirectToConfirmEmailNotification()
        {
            return Redirect("/Account/ConfirmEmailNotification");
        }
    }
}
