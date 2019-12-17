//-----------------------------------------------------------------------
// <copyright file="Vendor.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.InvoiceModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Vendor" />
    /// </summary>
    public class Vendor : InvoiceDate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vendor"/> class.
        /// </summary>
        public Vendor()
        {
            this.Created = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the VendorId
        /// </summary>
        [Key]
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the VendorName
        /// </summary>
        [Required(ErrorMessage = "Kérem adja meg a nevét!")]
        [Display(Name = "Név")]
        [StringLength(50)]
        public string VendorName { get; set; }

        /// <summary>
        /// Gets or sets the ContactName
        /// </summary>
        [Display(Name = "Kapcsolattartó")]
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        [Required(ErrorMessage = "Kérem adja meg a címét")]
        [StringLength(100)]
        [Display(Name = "Cím")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Phone
        /// </summary>
        [Required(ErrorMessage = "Adjon meg egy telefonszámot!")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefonszám")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the Fax
        /// </summary>
        [Display(Name = "Fax")]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Az E-mail cím nem megfelelő formátumú")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Website
        /// </summary>
        [Display(Name = "Weboldal")]
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the TaxNumber
        /// </summary>
        [Display(Name = "Adószám")]
        [Required]
        public string TaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the TaxNumberEU
        /// </summary>
        [Display(Name = "EU Adószám")]
        public string TaxNumberEU { get; set; }

        /// <summary>
        /// Gets or sets the AccountNumber
        /// </summary>
        [Display(Name = "Bankszámlaszám")]
        [Required]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the Information
        /// </summary>
        [Display(Name = "Információ")]
        public string Information { get; set; }
    }
}
