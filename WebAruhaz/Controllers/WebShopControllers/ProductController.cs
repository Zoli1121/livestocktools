//-----------------------------------------------------------------------
// <copyright file="ProductController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.WebShopControllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using WebAruhaz.Models.ViewModels.WebShopViewModels;
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="ProductController" />
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// Defines the productService
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// Defines the categoryService
        /// </summary>
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Defines the pageSize
        /// </summary>
        private int pageSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productService">The productService<see cref="IProductService"/></param>
        /// <param name="categoryService">The categoryService<see cref="ICategoryService"/></param>
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        /// <summary>
        /// Gets or sets the PageSize
        /// </summary>
        public int PageSize { get; set; } = 4;

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ViewResult"/></returns>
        public ViewResult Index()
        {
            return View(productService.Products);
        }

        /// <summary>
        /// The List
        /// </summary>
        /// <param name="cat">The cat<see cref="string"/></param>
        /// <param name="productPage">The productPage<see cref="int"/></param>
        /// <returns>The <see cref="ViewResult"/></returns>
        public ViewResult List(string cat, int productPage = 1)
        {
            IEnumerable<Product> products;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(cat))
            {
                products = productService.Products.OrderBy(p => p.ProductId);
                currentCategory = "Összes termék";
            }
            else
            {
                products = productService.Products.Where(p => p.SubSubCategory.CategoryName.Equals(cat)).OrderBy(p => p.Name);
                currentCategory = cat;
            }

            ProductsListViewModel productsListViewModel = new ProductsListViewModel
            {
                Products = products.Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PageViewModel = new PageViewModel
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = productService.Products.Count()
                },
                CurrentCategory = currentCategory
            };
            return View(productsListViewModel);
        }

        /// <summary>
        /// The Details
        /// </summary>
        /// <param name="productId">The productId<see cref="int"/></param>
        /// <returns>The <see cref="ViewResult"/></returns>
        public ViewResult Details(int productId)
        {
            Product product = productService.Products.FirstOrDefault(d => d.ProductId == productId);
            if (product == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }

            return View(product);
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="searchString">The searchString<see cref="string"/></param>
        /// <param name="productPage">The productPage<see cref="int"/></param>
        /// <returns>The <see cref="ViewResult"/></returns>
        public ViewResult Search(string searchString, int productPage = 1)
        {
            string search = searchString;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(search))
            {
                products = productService.Products.OrderBy(p => p.ProductId);
            }
            else
            {
                products = productService.Products.Where(p => p.Name.ToLower().Contains(searchString.ToLower()));
            }

            ProductsListViewModel productsListViewModel = new ProductsListViewModel
            {
                Products = products.Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PageViewModel = new PageViewModel
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = productService.Products.Count()
                },
                CurrentCategory = "All Products"
            };
            return View("~/Views/Product/List.cshtml", productsListViewModel);
        }
    }
}
