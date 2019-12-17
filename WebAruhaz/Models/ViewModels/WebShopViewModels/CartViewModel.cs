//-----------------------------------------------------------------------
// <copyright file="CartViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.WebShopViewModels
{
    using WebAruhaz.Services.WebShopServices;

    /// <summary>
    /// Defines the <see cref="CartViewModel" />
    /// </summary>
    public class CartViewModel
    {
        /// <summary>
        /// Gets or sets the Cart
        /// </summary>
        public CartService Cart { get; set; }

        /// <summary>
        /// Gets or sets the CartTotal
        /// </summary>
        public decimal CartTotal { get; set; }
    }
}
