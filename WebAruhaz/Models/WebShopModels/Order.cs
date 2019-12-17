//-----------------------------------------------------------------------
// <copyright file="Order.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.WebShopModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WebAruhaz.Models.InvoiceModels;

    /// <summary>
    /// Defines the <see cref="Order" />
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the OrderId
        /// </summary>
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the CustomerId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        [Required(ErrorMessage = "Adja meg a szállítási címet!")]
        [StringLength(100)]
        [Display(Name = "Szállítási cím")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the ShippingMethod
        /// </summary>
        [Display(Name = "Szállítási mód")]
        public string ShippingMethod { get; set; }

        /// <summary>
        /// Gets or sets the PaymentMethod
        /// </summary>
        [Display(Name = "Fizetési mód")]
        [Required]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the OrderPlaced
        /// </summary>
        public DateTime OrderPlaced { get; set; }

        /// <summary>
        /// Gets or sets the Lines
        /// </summary>
        public List<OrderDetail> Lines { get; set; }
    }
}
