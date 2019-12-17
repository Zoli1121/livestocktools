//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.InvoiceModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Currency" />
    /// </summary>
    public class Currency : InvoiceDate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        public Currency()
        {
            this.Created = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the CurrencyId
        /// </summary>
        [Key]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the CurrencyCode
        /// </summary>
        [Display(Name = "Kód")]
        [Required]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the CurrencyName
        /// </summary>
        [Display(Name = "Pénznem")]
        [Required]
        public string CurrencyName { get; set; }
    }
}
