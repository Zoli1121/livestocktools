//-----------------------------------------------------------------------
// <copyright file="OrderService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WebShopServices
{
    using System;
    using System.Collections.Generic;
    using WebAruhaz.Data;
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="OrderService" />
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Defines the _cart
        /// </summary>
        private readonly CartService cart;

        /// <summary>
        /// Defines the _dbContext
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="cont">The dbContext<see cref="ApplicationDbContext"/></param>
        /// <param name="cart">The cart<see cref="CartService"/></param>
        public OrderService(ApplicationDbContext cont, CartService cart)
        {
            context = cont;
            this.cart = cart;
        }

        /// <summary>
        /// The CreateOrder
        /// </summary>
        /// <param name="order">The order<see cref="Order"/></param>
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            context.Orders.Add(order);

            List<CartLine> cartLines = cart.ShoppingLists;
            foreach (CartLine cartLine in cartLines)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = cartLine.Quantity,
                    ProductRefId = cartLine.Product.ProductId,
                    OrderReferId = order.OrderId,
                    Price = cartLine.Product.Price
                };
                context.OrderDetails.Add(orderDetail);
            }

            context.SaveChanges();
        }
    }
}
