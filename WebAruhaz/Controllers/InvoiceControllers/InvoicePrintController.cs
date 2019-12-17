//-----------------------------------------------------------------------
// <copyright file="InvoicePrintController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.InvoiceControllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="InvoicePrintController" />
    /// </summary>
    public class InvoicePrintController : Controller
    {
        /// <summary>
        /// The Invoice
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Invoice()
        {
            return View();
        }

        /// <summary>
        /// The InvoicePrint
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult InvoicePrint()
        {
            return View();
        }
    }
}
