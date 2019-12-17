//-----------------------------------------------------------------------
// <copyright file="ProductsListViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.WebShopViewModels
{
    using System.Collections.Generic;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="ProductsListViewModel" />
    /// </summary>
    public class ProductsListViewModel
    {
        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the PageViewModel
        /// </summary>
        public PageViewModel PageViewModel { get; set; }

        /// <summary>
        /// Gets or sets the CurrentCategory
        /// </summary>
        public string CurrentCategory { get; set; }
    }
}
