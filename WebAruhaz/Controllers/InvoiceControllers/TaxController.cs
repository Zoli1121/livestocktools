//-----------------------------------------------------------------------
// <copyright file="TaxController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.InvoiceControllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebAruhaz.Data;

    /// <summary>
    /// Defines the <see cref="TaxController" />
    /// </summary>
    [Authorize(Roles = "Tax")]
    public class TaxController : Controller
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxController"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/></param>
        public TaxController(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
