//-----------------------------------------------------------------------
// <copyright file="NewProductsViewModel.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.Models.ViewModels.WebShopViewModels
{
    using System.Collections.Generic;
    using WebAruhaz.Models.WebShopModels;

    /// <summary>
    /// Defines the <see cref="NewProductsViewModel" />
    /// </summary>
    public class NewProductsViewModel
    {
        /// <summary>
        /// Gets or sets the NewProducts
        /// </summary>
        public IEnumerable<Product> NewProducts { get; set; }
    }
}
