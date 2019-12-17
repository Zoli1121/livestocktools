//-----------------------------------------------------------------------
// <copyright file="CategoryService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WebShopServices
{
    using System.Collections.Generic;
    using WebAruhaz.Data;
    using WebAruhaz.Models.WebShopModels;
    using WebAruhaz.Services.WebShopServices.Interfaces;

    /// <summary>
    /// Defines the <see cref="CategoryService" />
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="appDbContext">The appDbContext<see cref="ApplicationDbContext"/></param>
        public CategoryService(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        /// <summary>
        /// Gets the Categories
        /// </summary>
        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }
    }
}
