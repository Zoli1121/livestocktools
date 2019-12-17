//-----------------------------------------------------------------------
// <copyright file="ProductService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WebShopServices
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using WebAruhaz.Data;
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="ProductService" />
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationDbContext"/></param>
        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the Products
        /// </summary>
        public IEnumerable<Product> Products
        {
            get { return context.Products.Include(c => c.SubSubCategory); }
        }

        /// <summary>
        /// Gets the NewProducts
        /// </summary>
        public IEnumerable<Product> NewProducts
        {
            get { return context.Products.Take(3); }
        }

        /// <summary>
        /// The GetProductById
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <returns>The <see cref="Product"/></returns>
        public Product GetProductById(int productId)
        {
            return context.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        /// <summary>
        /// The SaveProduct
        /// </summary>
        /// <param name="p">The product<see cref="Product"/></param>
        public void SaveProduct(Product p)
        {
            if (p.ProductId == 0)
            {
                context.Products.Add(p);
            }
            else
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductId == p.ProductId);
                if (product != null)
                {
                    product.Name = p.Name;
                    product.PartNumber = p.PartNumber;
                    product.Description = p.Description;
                    product.Price = p.Price;
                    product.Image = p.Image;
                    product.SmallImage = p.SmallImage;
                    product.InStock = p.InStock;
                    product.MadeTime = p.MadeTime;
                    product.SerialNumber = p.SerialNumber;
                    product.Batch = p.Batch;
                    product.Weight = p.Weight;
                    product.QuantityUnit = p.QuantityUnit;
                    product.CategoryRefId = p.CategoryRefId;
                    product.SubCategoryRefId = p.SubCategoryRefId;
                    product.SubSubCategoryRefId = p.SubSubCategoryRefId;
                    product.SubSubCategory = p.SubSubCategory;
                    product.WareHouseRefId = p.WareHouseRefId;
                    product.Warehouse = p.Warehouse;
                    product.RackRefId = p.RackRefId;
                    product.Rack = p.Rack;
                }
            }

            context.SaveChanges();
        }

        /// <summary>
        /// The DeleteProduct
        /// </summary>
        /// <param name="productID">The productID<see cref="int"/></param>
        /// <returns>The <see cref="Product"/></returns>
        public Product DeleteProduct(int productID)
        {
            Product product = context.Products
                .FirstOrDefault(p => p.ProductId == productID);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }

            return product;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="product">The product<see cref="Product"/></param>
        public void Update(Product product)
        {
            context.Update(product);
        }
    }
}
