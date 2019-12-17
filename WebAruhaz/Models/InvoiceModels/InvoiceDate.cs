//-----------------------------------------------------------------------
// <copyright file="InvoiceDate.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.InvoiceModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="InvoiceDate" />
    /// </summary>
    public class InvoiceDate
    {
        /// <summary>
        /// Gets or sets the Created
        /// </summary>
        [Display(Name = "Számla kelte")]
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
