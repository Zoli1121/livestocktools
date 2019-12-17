//-----------------------------------------------------------------------
// <copyright file="IOrderService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WebShopServices.Interfaces
{
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="IOrderService" />
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// The CreateOrder
        /// </summary>
        /// <param name="order">The order<see cref="Order"/></param>
        void CreateOrder(Order order);
    }
}
