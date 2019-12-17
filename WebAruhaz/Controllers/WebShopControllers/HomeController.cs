//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.WebShopControllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebAruhaz.Models.ViewModels.WebShopViewModels;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="HomeController" />
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Defines the _productService
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="productService">The productService<see cref="IProductService"/></param>
        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ViewResult"/></returns>
        public ViewResult Index()
        {
            var newProductsViewModel = new NewProductsViewModel
            {
                NewProducts = productService.NewProducts
            };
            return View(newProductsViewModel);
        }

        /// <summary>
        /// The test
        /// </summary>
        /// <returns>The <see cref="ViewResult"/></returns>
        public ViewResult Test()
        {
            return View();
        }
    }
}
