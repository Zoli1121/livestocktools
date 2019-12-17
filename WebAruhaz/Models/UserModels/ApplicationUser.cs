//-----------------------------------------------------------------------
// <copyright file="ApplicationUser.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.UserModels
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    
    /// <summary>
    /// Defines the <see cref="ApplicationUser" />
    /// </summary>
    public partial class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets a value indicating whether MainAdmin
        /// </summary>
        [Display(Name = "Fő adminisztrátor")]
        public bool MainAdmin { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether WebRole
        /// </summary>
        [Display(Name = "Vásárlás")]
        public bool WebRole { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether InvoiceRole
        /// </summary>
        [Display(Name = "Számlázás")]
        public bool InvoiceRole { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether TaxRole
        /// </summary>
        [Display(Name = "Adózás")]
        public bool TaxRole { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether OrderRole
        /// </summary>
        [Display(Name = "Rendelés adminisztráció")]
        public bool OrderRole { get; set; } = false;
    }
}
