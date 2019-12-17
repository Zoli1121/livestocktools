//-----------------------------------------------------------------------
// <copyright file="CartSummaryView.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.ViewComponents
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WebAruhaz.Models.ViewModels.WebShopViewModels;
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WebShopServices;

    /// <summary>
    /// Defines the <see cref="CartSummaryView" />
    /// </summary>
    public class CartSummaryView : ViewComponent
    {
        /// <summary>
        /// Defines the cart
        /// </summary>
        private readonly CartService cart;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartSummaryView"/> class.
        /// </summary>
        /// <param name="cart">The cart<see cref="CartService"/></param>
        public CartSummaryView(CartService cart)
        {
            this.cart = cart;
        }

        /// <summary>
        /// The Invoke
        /// </summary>
        /// <returns>The <see cref="IViewComponentResult"/></returns>
        public IViewComponentResult Invoke()
        {
            List<CartLine> cartLines = this.cart.GetCartLines();
            this.cart.ShoppingLists = cartLines;

            CartViewModel cartViewModel = new CartViewModel
            {
                Cart = this.cart,
                CartTotal = this.cart.GetCartTotal()
            };
            return this.View(cartViewModel);
        }
    }
}
