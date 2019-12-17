//-----------------------------------------------------------------------
// <copyright file="Tax.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.InvoiceModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Tax" />
    /// </summary>
    public class Tax : InvoiceDate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tax"/> class.
        /// </summary>
        public Tax()
        {
            this.Created = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the TaxId
        /// </summary>
        [Key]
        public int TaxId { get; set; }

        /// <summary>
        /// Gets or sets the TaxLabel
        /// </summary>
        [Display(Name = "Adó típus")]
        [Required]
        public string TaxLabel { get; set; }

        /// <summary>
        /// Gets or sets the TaxRate
        /// </summary>
        [Display(Name = "Adó százalék")]
        [Required]
        public float TaxRate { get; set; }
    }
}
