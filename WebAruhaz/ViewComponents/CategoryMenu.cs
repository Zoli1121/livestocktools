//-----------------------------------------------------------------------
// <copyright file="CategoryMenu.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.ViewComponents.CategoryMenuService
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
   
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="CategoryMenu" />
    /// </summary>
    public class CategoryMenu : ViewComponent
    {
        /// <summary>
        /// Defines the _categoryService
        /// </summary>
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMenu"/> class.
        /// </summary>
        /// <param name="categoryService">The categoryService<see cref="ICategoryService"/></param>
        public CategoryMenu(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        /// <summary>
        /// The Invoke
        /// </summary>
        /// <returns>The <see cref="IViewComponentResult"/></returns>
        public IViewComponentResult Invoke()
        {
            IOrderedEnumerable<Category> categories = this.categoryService.Categories.OrderBy(p => p.CategoryName);
            return this.View(categories.ToList());
        }
    }
}
