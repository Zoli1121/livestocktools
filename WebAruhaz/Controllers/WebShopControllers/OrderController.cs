//-----------------------------------------------------------------------
// <copyright file="OrderController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.WebShopControllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WebShopServices;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="OrderController" />
    /// </summary>
    public class OrderController : Controller
    {
        /// <summary>
        /// Defines the _orderService
        /// </summary>
        private readonly IOrderService orderService;

        /// <summary>
        /// Defines the _cart
        /// </summary>
        private readonly CartService cart;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="orderService">The orderService<see cref="IOrderService"/></param>
        /// <param name="cart">The cart<see cref="CartService"/></param>
        public OrderController(IOrderService orderService, CartService cart)
        {
            this.orderService = orderService;
            this.cart = cart;
        }

        /// <summary>
        /// The Checkout
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        /// <summary>
        /// The Checkout
        /// </summary>
        /// <param name="order">The order<see cref="Order"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            List<CartLine> cartLines = cart.GetCartLines();
            cart.ShoppingLists = cartLines;
            if (cart.ShoppingLists.Count == 0)
            {
                ModelState.AddModelError("", "A bevásárlókocsi üres, tegyél bele terméket!");
            }

            if (ModelState.IsValid)
            {
                orderService.CreateOrder(order);
                cart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        /// <summary>
        /// The CheckoutComplete
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Köszönjük a rendelését! :) ";
            return View();
        }
    }
}
