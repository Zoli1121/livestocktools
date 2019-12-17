//-----------------------------------------------------------------------
// <copyright file="Invoice.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.InvoiceModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="Invoice" />
    /// </summary>
    public class Invoice : InvoiceDate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        public Invoice()
        {
            this.InvoiceDate = DateTime.UtcNow;
            this.InvoiceNumber = DateTime.UtcNow.Date.Year.ToString() +
                DateTime.UtcNow.Date.Month.ToString() +
                DateTime.UtcNow.Date.Day.ToString() + Guid.NewGuid().ToString().Substring(0, 4).ToUpper() + "INV";
            this.DueDate = DateTime.UtcNow.Date.AddMonths(1);
        }

        /// <summary>
        /// Gets or sets the InvoiceId
        /// </summary>
        [Key]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceNumber
        /// </summary>
        [Display(Name = "Számlaszám")]
        [Required]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the VendorRefId
        /// </summary>
        [Display(Name = "Számlakibocsátó neve, címe")]
        [Required]
        [ForeignKey("Vendor")]
        public int VendorRefId { get; set; }

        /// <summary>
        /// Gets or sets the Vendor
        /// </summary>
        public Vendor Vendor { get; set; }

        /// <summary>
        /// Gets or sets the CustomerRefId
        /// </summary>
        [Display(Name = "Vevő neve, címe")]
        [Required]
        [ForeignKey("Customer")]
        public int CustomerRefId { get; set; }

        /// <summary>
        /// Gets or sets the Customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceDate
        /// </summary>
        [Display(Name = "Kelt")]
        [Required]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets the PaidDateTime
        /// </summary>
        [Display(Name = "Teljesítés dátuma")]
        [Required]
        public DateTime PaidDateTime { get; set; }

        /// <summary>
        /// Gets or sets the DueDate
        /// </summary>
        [Display(Name = "Fizetési határidő")]
        [Required]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the Orders
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the NetPrice
        /// </summary>
        [Display(Name = "Nettó")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetPrice { get; set; }

        /// <summary>
        /// Gets or sets the Gross
        /// </summary>
        [Display(Name = "Bruttó")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Gross { get; set; }

        /// <summary>
        /// Gets or sets the TaxRefId
        /// </summary>
        [Display(Name = "Adó")]
        [Required]
        [ForeignKey("Tax")]
        public int TaxRefId { get; set; }

        /// <summary>
        /// Gets or sets the Tax
        /// </summary>
        public Tax Tax { get; set; }

        /// <summary>
        /// Gets or sets the TaxAmount
        /// </summary>
        [Display(Name = "Adó alap")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the Shipping
        /// </summary>
        [Display(Name = "Szállítási költség")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Shipping { get; set; }

        /// <summary>
        /// Gets or sets the Discount
        /// </summary>
        [Display(Name = "Kedvezmény")]
        public int Discount { get; set; }

        /// <summary>
        /// Gets or sets the CurrencyRefId
        /// </summary>
        [Display(Name = "Pénznem")]
        [Required]
        [ForeignKey("Currency")]
        public int CurrencyRefId { get; set; }

        /// <summary>
        /// Gets or sets the Currency
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the NoteToRecipient
        /// </summary>
        [Display(Name = "Átvevő")]
        public string NoteToRecipient { get; set; }
    }
}
