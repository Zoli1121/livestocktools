//-----------------------------------------------------------------------
// <copyright file="CartController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.WebShopControllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using WebAruhaz.Models.ViewModels.WebShopViewModels;
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WebShopServices;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="CartController" />
    /// </summary>
    public class CartController : Controller
    {
        /// <summary>
        /// Defines the _productService
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// Defines the _cart
        /// </summary>
        private readonly CartService cart;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController"/> class.
        /// </summary>
        /// <param name="productService">The productService<see cref="IProductService"/></param>
        /// <param name="cart">The cart<see cref="CartService"/></param>
        public CartController(IProductService productService, CartService cart)
        {
            this.productService = productService;
            this.cart = cart;
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ViewResult"/></returns>
        [Authorize]
        public ViewResult Index()
        {
            List<CartLine> items = cart.GetCartLines();
            cart.ShoppingLists = items;

            CartViewModel cartViewModel = new CartViewModel
            {
                Cart = cart,
                CartTotal = cart.GetCartTotal()
            };
            return View(cartViewModel);
        }

        /// <summary>
        /// The AddToCart
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <returns>The <see cref="RedirectToActionResult"/></returns>
        [Authorize]
        public RedirectToActionResult AddToCart(int productId)
        {
            Product selectedProduct = productService.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectedProduct != null)
            {
                cart.AddToCart(selectedProduct, 1);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// The RemoveFromCart
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <returns>The <see cref="RedirectToActionResult"/></returns>
        public RedirectToActionResult RemoveFromCart(int productId)
        {
            Product selectedProduct = productService.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectedProduct != null)
            {
                cart.RemoveFromCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }
    }
}
