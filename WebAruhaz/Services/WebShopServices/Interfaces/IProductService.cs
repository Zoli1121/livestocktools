//-----------------------------------------------------------------------
// <copyright file="IProductService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WebShopServices.Interfaces
{
    using System.Collections.Generic;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="IProductService" />
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets the Products
        /// </summary>
        IEnumerable<Product> Products { get; }

        /// <summary>
        /// Gets the NewProducts
        /// </summary>
        IEnumerable<Product> NewProducts { get; }

        /// <summary>
        /// The SaveProduct
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        void SaveProduct(Product product);

        /// <summary>
        /// The DeleteProduct
        /// </summary>
        /// <param name="productID">The productID<see cref="int"/></param>
        /// <returns>The <see cref="Product"/></returns>
        Product DeleteProduct(int productID);

        /// <summary>
        /// The GetProductById
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <returns>The <see cref="Product"/></returns>
        Product GetProductById(int productId);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        void Update(Product product);
    }
}
