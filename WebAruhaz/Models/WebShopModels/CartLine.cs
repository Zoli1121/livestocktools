//-----------------------------------------------------------------------
// <copyright file="CartLine.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.WebShopModels
{
    /// <summary>
    /// Defines the <see cref="CartLine" />
    /// </summary>
    public class CartLine
    {
        /// <summary>
        /// Gets or sets the CartLineId
        /// </summary>
        public int CartLineId { get; set; }

        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the CartId
        /// </summary>
        public string CartId { get; set; }
    }
}
