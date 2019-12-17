//-----------------------------------------------------------------------
// <copyright file="ICategoryService.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Services.WebShopServices.Interfaces
{
    using System.Collections.Generic;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="ICategoryService" />
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Gets the Categories
        /// </summary>
        IEnumerable<Category> Categories { get; }
    }
}
