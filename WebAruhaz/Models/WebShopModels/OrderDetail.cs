//-----------------------------------------------------------------------
// <copyright file="OrderDetail.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.WebShopModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="OrderDetail" />
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// Gets or sets the OrderDetailId
        /// </summary>
        [Key]
        public int OrderDetailId { get; set; }

        /// <summary>
        /// Gets or sets the ProductRefId
        /// </summary>
        [ForeignKey("Product")]
        public int ProductRefId { get; set; }

        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the OrderReferId
        /// </summary>
        [ForeignKey("Order")]
        public int OrderReferId { get; set; }

        /// <summary>
        /// Gets or sets the Order
        /// </summary>
        public Order Order { get; set; }
    }
}
