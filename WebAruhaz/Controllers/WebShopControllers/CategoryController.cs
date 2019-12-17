//-----------------------------------------------------------------------
// <copyright file="CategoryController.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Controllers.WebShopControllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="CategoryController" />
    /// </summary>
    public class CategoryController : Controller
    {
        /// <summary>
        /// Defines the _categoryService
        /// </summary>
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="categoryService">The categoryService<see cref="ICategoryService"/></param>
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
