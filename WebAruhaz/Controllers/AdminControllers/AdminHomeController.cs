//-----------------------------------------------------------------------
// <copyright file="AdminHomeController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.AdminControllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using WebAruhaz.AccessManagement;

    /// <summary>
    /// Defines the <see cref="AdminHomeController" />
    /// </summary>
    public class AdminHomeController : Controller
    {
        /// <summary>
        /// Defines the _logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminHomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger<see cref="ILogger{AdminHomeController}"/></param>
        public AdminHomeController(ILogger<AdminHomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [Authorize]
        public IActionResult Index()
        {
            logger.LogInformation(LoggingEvents.ListItems, "Listing Home Index");
            return View();
        }
    }
}
