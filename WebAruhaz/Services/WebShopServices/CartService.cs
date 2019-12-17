//-----------------------------------------------------------------------
// <copyright file="CartService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WebShopServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using WebAruhaz.Data;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="CartService" />
    /// </summary>
    public class CartService
    {
        /// <summary>
        /// Defines the context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/></param>
        public CartService(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets or sets the CartId
        /// </summary>
        public string CartId { get; set; }

        /// <summary>
        /// Gets or sets the ShoppingLists
        /// </summary>
        public List<CartLine> ShoppingLists { get; set; }

        /// <summary>
        /// The GetCart
        /// </summary>
        /// <param name="services">The services<see cref="IServiceProvider"/></param>
        /// <returns>The <see cref="CartService"/></returns>
        public static CartService GetCart(IServiceProvider services)
        {
            IHttpContextAccessor httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();

            ISession session;
            if (httpContextAccessor != null)
            {
                session = httpContextAccessor.HttpContext.Session;
            }
            else
            {
                session = null;
            }

            ApplicationDbContext context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId");
            if (cartId == null)
            {
                cartId = Guid.NewGuid().ToString();
            }

            session.SetString("CartId", cartId);
            return new CartService(context)
            {
                CartId = cartId
            };
        }

        /// <summary>
        /// The AddToCart
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        /// <param name="quantity">The quantity<see cref="int"/></param>
        public void AddToCart(Product product, int quantity)
        {
            DbSet<CartLine> cartLinesDb = context.CartLines;
            CartLine cartLine = cartLinesDb.SingleOrDefault(c => c.Product.ProductId == product.ProductId && c.CartId == CartId);

            if (cartLine == null)
            {
                cartLine = new CartLine
                {
                    CartId = CartId,
                    Product = product,
                    Quantity = 1
                };

                cartLinesDb.Add(cartLine);
            }
            else
            {
                cartLine.Quantity++;
            }

            context.SaveChanges();
        }

        /// <summary>
        /// The RemoveFromCart
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int RemoveFromCart(Product product)
        {
            DbSet<CartLine> cartLinesDb = context.CartLines;
            CartLine cartLine = cartLinesDb.SingleOrDefault(c => c.Product.ProductId == product.ProductId && c.CartId == CartId);

            int quantity = 0;
            if (cartLine != null)
            {
                if (cartLine.Quantity > 1)
                {
                    cartLine.Quantity--;
                    quantity = cartLine.Quantity;
                }
                else
                {
                    cartLinesDb.Remove(cartLine);
                }
            }

            context.SaveChanges();

            return quantity;
        }

        /// <summary>
        /// The GetCartLines
        /// </summary>
        /// <returns>The <see cref="List{CartLine}"/></returns>
        public List<CartLine> GetCartLines()
        {
            DbSet<CartLine> cartLinesDb = context.CartLines;
            IQueryable<CartLine> cartLines = cartLinesDb.Where(c => c.CartId == CartId);

            var list = ShoppingLists;
            if (list != null)
            {
                return list;
            }

            return ShoppingLists = cartLines.Include(c => c.Product).ToList();
        }

        /// <summary>
        /// The ClearCart
        /// </summary>
        public void ClearCart()
        {
            DbSet<CartLine> cartLinesDb = context.CartLines;
            IQueryable<CartLine> cartLines = cartLinesDb.Where(c => c.CartId == CartId);

            cartLinesDb.RemoveRange(cartLines);
            context.SaveChanges();
        }

        /// <summary>
        /// The GetCartTotal
        /// </summary>
        /// <returns>The <see cref="decimal"/></returns>
        public decimal GetCartTotal()
        {
            DbSet<CartLine> cartLinesDb = context.CartLines;
            IQueryable<CartLine> cartLines = cartLinesDb.Where(c => c.CartId == CartId);

            decimal sum = cartLines.Select(c => c.Product.Price * c.Quantity).Sum();
            return sum;
        }
    }
}
